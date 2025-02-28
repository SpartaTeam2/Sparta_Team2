게임 빌드 파일 [Google Drive](https://drive.google.com/file/d/1HRsLuNn90q5JHxQD2z5B4aY_FMiPvOMZ/view?usp=sharing) <br>
게임 시연 영상 [Youtubue](https://youtu.be/jbC7f0dJeow?si=R4VFNT3baBaxOJCg)

### 스파르타 내일배움캠프 유니티 7/8기  

Unity 게임 개발 입문 팀프로젝트<br>
~~궁수의전설인척 하는것~~

<p>$\huge{\rm{\color{#5ad7b7}팀장 : 이상범}}$</p>
<p>$\it{\large{\color{#DD6565}팀원 : 박민영 / 류석민 / 천지훈 / 한재민}}$</p>

1. [Intro Scene](#00_intro-scene)
2. [Lobby Scene](#01_lobby-scene)
3. [02_Battle Scene](#02_battle-scene)

---

## 00_Intro Scene
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
