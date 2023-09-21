# Balance-ATM

![personal](https://github.com/riviea/Balance-ATM/assets/12423098/dcf2e2fb-f410-4a2c-a01e-2555215830a0)

### Summary
- `UIManager` 클래스에서 현재 Scene의 이름을 기준으로 미리 제작된(Prefab) UI 생성
- 생성된 UI 중 `ATM_System` 컴포넌트를 가진 객체가 `Awake` 될 때…
  - 싱글톤 오브젝트 `WalletManager`의 `ATM_System` 변수에 Attach.
- `ATM_System` 객체는 `WalletData`, `WalletBehavior`, `WalletDisplayer`를 관리함
  - `ATM_System`가 갖고 있는 `WalletData` 객체로 계좌/지갑 잔고를 관리
  - `WalletBehavior` 객체는 입금, 출금 UI 기능 담당
  - `WalletDisplayer` 객체는 현재 잔고 UI 기능 담당
