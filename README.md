게임 빌드 파일 [Google Drive](https://drive.google.com/file/d/1YW1Oy8xd_1LnD1eyXGP8agmipiIaL1t1/view?usp=sharing) <br>
게임 시연 영상 [Youtubue](https://youtu.be/jbC7f0dJeow?si=R4VFNT3baBaxOJCg)

### 스파르타 내일배움캠프 유니티 7/8기  

Unity 게임 개발 입문 팀프로젝트<br>
~~궁수의전설인척 하는것~~

<p>$\huge{\rm{\color{#5ad7b7}팀장 : 이상범}}$</p>
<p>$\it{\large{\color{#DD6565}팀원 : 박민영 / 류석민 / 천지훈 / 한재민}}$</p>

- 목차
  - [00 Intro Scene](#00_intro-scene)
  - [01Lobby Scene](#01_lobby-scene)
  - [02_Battle Scene](#02_battle-scene)
  - [기술 관련](#기술관련)
---
# 게임 설명
### 00_Intro Scene
![image](https://github.com/user-attachments/assets/ebe964f3-a943-4748-b1b3-99946547e436)
- 클릭시 01_Lobby Scene으로 넘어갑니다.

### 01_Lobby Scene
![image](https://github.com/user-attachments/assets/6943964a-27c4-4d2c-b04e-29f456b3618c)
 - 던전 레벨++ -- 초기화는 테스트용도로 놔둔것이니 무시해주세요.
 - 설정 -> 사운드 조절 -> BGM / SFX 사운드 조절 가능
 - 전투 -> 02_Battle Scene으로 넘어갑니다.
 - 배경
   - 스테이지 배경 이미지 페이드인/아웃
   - 스테이지 보스 이미지 페이드인/아웃
 
### 02_Battle Scene
![image](https://github.com/user-attachments/assets/e23051b8-d91e-4ba7-9126-2077193d466a)
- 스테이지가 클리어되면 획득한 경험치들을 레벨로 환산하고, 획득한 레벨만큼 스킬을 선택합니다.
![image](https://github.com/user-attachments/assets/f0e80ddd-a983-49c7-9342-50d568633e00)
- 플레이어는 가장 가까운 적을 자동으로 공격합니다.
- 몬스터는 플레이어를 추적 및 원거리 or 근거리 공격을합니다.
- 몬스터가 공격시 경고선이 우선 출력 후 공격합니다.
- 피격시 하트 이펙트 / 몬스터의 공격은 보라색 이펙트 / 플레이어의 공격은 노란색, 파란색 이펙트가 발생합니다.
![image](https://github.com/user-attachments/assets/740e9691-fec9-475e-b254-f67702212d93)
- 10스테이지까지 클리어시 던전레벨이 1 올라갑니다.

# 기술관련
### 스테이지 
- 작업자 : 이상범
![image](https://github.com/user-attachments/assets/e35da1f4-6561-4e00-bce9-ec32fac64d77)

### 몬스터
- 작업자 : 한재민
- FSM 구조 몬스터의 동작을 구현했습니다.
- 공격 경고선 / 피격,공격 이펙트는 싱글톤과 오브젝트풀링을 사용했습니다.
![image](https://github.com/user-attachments/assets/0745af66-c407-4763-bbbc-eac8050e2b0d)
![image](https://github.com/user-attachments/assets/8e7ca864-5764-4adc-b907-715b34197418)


### 스킬 구현
- 작업자 : 류석민
- 카드 생성 플로우
  - 랜덤 생성 스킬 등급 설정
  - 해당 등급 Dictinary에서 생성 가능 여부 value 확인후 Random 선택
  - 스킬 카드 오브젝트 생성
- 카드 선택 애니메이션
  - 선택한 카드 중앙 이동
  - 이후 카드 오브젝트 파괴<br>
![image](https://github.com/user-attachments/assets/c86ae4af-fa5f-443c-a1aa-735c3d5fab57)
![image](https://github.com/user-attachments/assets/a9ccc068-cd61-4578-981e-282807c11bde)

### 인게임 UI
- 작업자 : 박민영
- 씬 UI
  - 인스펙터창에서 원하는 씬을 입력해서 불러오도록 제작
- 전투 UI
  - 플레이어의 정보를 받아와서 제작 <br>
![image](https://github.com/user-attachments/assets/a6ab7eb9-b303-437f-9379-6cc5686e791a)
![image](h범
- 싱글톤 적용
- SFX의 경우 중복재생을 위해 AudioSource Component를 리스트에 미리 추가
- 재생되고 있지 않은 AudioSource를 찾아 재생할 수 있도록 구현
![image](https://github.com/user-attachments/assets/5580fbb8-d699-40d5-a929-356a6b55ba43)

