#Conveyor Transfer Unit

##Equipment Specification
목적
작업자가 투입한 제품을 A 위치에서 B 위치까지 자동 이송한다.

구성
- Conveyor Motor × 1
- Product Load Photo Sensor × 1
- Product Arrival Photo Sensor × 1
- Motor Running Signal × 1

동작
A 위치 제품 감지
→ Conveyor Run
→ B 위치 제품 도착
→ Conveyor Stop
→ Transfer Complete


##I/O List

[INPUT]
Signal Name | Description | Purpose

     X1.Product Load Photo Sensor / 투입위치 포토센서 / 제품 안착 확인 
     X2.Product Arrival Photo Senso / 배출위치 포터센서 / 제품 도착 확인  
     X3.Motor Running Signal / 컨베이어 모터 기동상태 신호 / 컨베이어 기동 확인 

[OUTPUT]
Signal Name | Description | Purpose

     Y1.Conveyor Motor / 컨베이어 모터 기동 명령/ 컨베이어 run/stop 제어 


## Auto Sequence

STEP 0 : 제품 투입 대기
동작 : Conveyor 정지
완료조건 : 제품 투입 확인
→ STEP 10

STEP 10 : 제품 이송
동작 : Conveyor 운전
완료조건 : 제품 도착 확인
→ STEP 20

STEP 20 : 제품 Unload 대기
동작 : Conveyor 정지
완료조건 : 제품 제거 확인
→ STEP 0