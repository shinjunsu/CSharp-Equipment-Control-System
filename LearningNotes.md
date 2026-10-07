# Learning Notes

## Day 1 - Conveyor Transfer Unit

### 1. PLC Sequence와 PC Sequence의 차이

PLC에서는 프로그램이 기본적으로 Scan되지만,
C#에서는 Sequence를 실행할 주기 구조를 직접 구성해야 한다.

이번 프로젝트에서는 WinForms Timer를 사용하여
100ms마다 `ConveyorSequence.Run()`을 호출하도록 구성했다.

Timer가 공정을 직접 제어하는 것이 아니라,
Sequence를 일정 주기로 호출하고 실제 공정 판단은
`ConveyorSequence`가 담당한다.


### 2. EquipmentIO와 Sequence 분리

센서와 출력 신호를 `EquipmentIO`에 모으고,
실제 공정 동작은 `ConveyorSequence`에서 판단하도록 분리했다.

가상 Sensor
→ EquipmentIO
→ ConveyorSequence
→ EquipmentIO Output
→ UI

이렇게 분리하면 이후 실제 PLC 통신으로 변경하더라도
Sequence는 신호가 체크박스에서 왔는지 PLC에서 왔는지 알 필요가 없다.


### 3. 하나의 EquipmentIO 객체 공유

`EquipmentIO`를 각 Sequence 내부에서 각각 `new` 하지 않고,
Form에서 하나의 객체를 생성한 뒤 생성자를 통해 Sequence에 전달했다.

이를 통해 이후 공정이 추가되어도
동일한 설비 I/O 상태를 여러 Sequence가 공유할 수 있다.

`readonly`는 I/O 값의 변경을 막는 것이 아니라,
처음 전달받은 `EquipmentIO` 객체가 다른 객체로 교체되는 것을 방지한다.


### 4. Step을 enum으로 관리

PLC에서는 0, 10, 20 등의 숫자로 Step을 관리할 수 있지만,
C#에서는 `enum`을 사용하여 상태에 이름을 부여했다.

- Wait
- Transfer
- Unload
- Error

숫자만 사용하는 것보다 현재 상태의 의미를 바로 알 수 있어
가독성과 유지보수성이 좋아진다.


### 5. State가 공정 상태를 기억한다

Product Load Sensor(X01)는 Transfer의 시작 조건일 뿐,
Transfer 중 계속 ON되어 있어야 하는 조건은 아니다.

제품이 X01을 벗어나 X02에 도착하기 전까지는
두 센서가 모두 OFF인 구간이 존재할 수 있다.

이때 `currentStep = Transfer`가
"현재 제품을 이송 중"이라는 상태를 기억하기 때문에
X01이 OFF되어도 Conveyor(Y01)는 계속 동작한다.

X01 = Transfer 진입 조건  
Transfer Step = 이송 중 상태 기억  
X02 = Transfer 종료 조건


### 6. Timeout은 Scan을 멈추지 않고 감시

Motor Run Command(Y01)가 ON된 후
2초 이내에 Motor Running Feedback(X03)이 들어오는지 확인했다.

`Thread.Sleep(2000)`처럼 실행 흐름을 2초 동안 정지시키는 대신
`Stopwatch.ElapsedMilliseconds`를 사용했다.

Sequence Scan은 계속 실행하면서
경과시간이 2000ms 이상인지 확인하여 Timeout을 판단한다.

PLC에서 Scan은 계속 돌고
Timer 완료 조건을 확인하는 것과 비슷하게 이해할 수 있다.


### 7. Timer 시작 위치

`Stopwatch.Restart()`를 Transfer 내부에서 매 Scan마다 실행하면
100ms마다 시간이 다시 0으로 초기화되어 Timeout이 발생할 수 없다.

따라서 Wait → Transfer로 상태가 변경되는 순간에 한 번만 `Restart()`하고,
Transfer에서는 경과시간만 확인하도록 구성했다.


### 8. Command와 Feedback은 다르다

`ConveyorRun(Y01)`은 모터를 운전하라는 Command이고,
`MotorRunning(X03)`은 모터가 실제로 운전 중이라는 Feedback이다.

Command가 ON되었다고 실제 장비가 정상 동작했다고 판단하면 안 된다.

따라서 Y01 ON 이후 X03 Feedback을 확인하고,
일정 시간 안에 Feedback이 없으면 Error로 전환하도록 했다.


### 9. Fault Simulation

실제 PLC와 모터가 없기 때문에
`Motor Feedback Fault Simulation` 체크박스를 만들어
고장을 강제로 발생시킬 수 있도록 했다.

정상 상태:

Y01 ON
→ X03 자동 ON
→ 정상 운전

Fault 상태:

Y01 ON
→ X03 OFF 유지
→ 2초 Timeout
→ Error


### 10. Reset의 의미

Reset은 고장 원인을 해결하는 기능이 아니다.

Error 발생
→ 고장 원인 제거
→ 제품/센서 상태 확인
→ Reset
→ Wait 복귀

고장 원인이 그대로라면
Reset을 해도 같은 Error가 다시 발생하는 것이 정상이다.

Reset 시 Sequence Step, Output, Timeout Timer 등
Sequence 내부 상태를 초기 상태로 정리한다.


### 11. C# 문법에서 다시 확인한 부분

- `객체.메서드()` : 객체에게 동작을 수행시킨다.
  - `sequence.Run()`
  - `timer.Start()`
  - `stopwatch.Reset()`

- `객체.Property` : 객체의 상태값을 읽거나 변경한다.
  - `checkBox.Checked`
  - `io.ProductLoad`
  - `stopwatch.ElapsedMilliseconds`

- `bool` : `true / false`로 ON/OFF 상태를 표현
- `!` : NOT
- `&&` : AND
- `?:` : 삼항 연산자
- `if`문은 한 줄이어도 `{ }`를 사용하는 습관을 들인다.
- `private` 상태는 클래스 내부에서 관리하고 외부에는 필요한 정보만 공개한다.


## Day 1 핵심 정리

PLC에서는 이미 제공되는 Scan과 I/O를 기반으로
Sequence Logic을 작성하는 경우가 많았다.

PC 제어에서는 I/O 객체, 실행 주기, 상태 관리,
Sequence와 UI의 역할 분리까지 프로그램 구조로 직접 구성해야 한다.

이번 Day 1에서는 PLC에서 알고 있던
Sequence / Command / Feedback / Timeout / Error / Reset 개념을
C# 객체와 State 기반 구조로 다시 구현해보았다.