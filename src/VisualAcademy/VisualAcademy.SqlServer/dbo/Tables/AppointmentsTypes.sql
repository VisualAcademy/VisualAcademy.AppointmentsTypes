-- AppointmentsTypes 테이블 생성 구문
-- 이 테이블은 예약 종류 정보를 담는 테이블이다.

CREATE TABLE AppointmentsTypes (
  Id INT PRIMARY KEY IDENTITY(1,1),
  AppointmentTypeName NVARCHAR(50) NOT NULL,
  IsActive BIT NOT NULL DEFAULT 1,
  DateCreated DATETIME NOT NULL DEFAULT GETDATE()
)

-- Id 열은 INT형으로, 기본키로 설정되며, 자동 증가하는 ID 값이다.
-- AppointmentTypeName 열은 NVARCHAR(50) 형으로, 예약 종류 이름을 저장한다. 이 열은 NULL 값을 허용하지 않는다.
-- IsActive 열은 BIT 형으로, 예약 종류가 활성화 상태인지 아닌지를 나타낸다. 이 열은 NULL 값을 허용하지 않으며, 디폴트 값은 1이다.
-- DateCreated 열은 DATETIME 형으로, 예약 종류가 생성된 날짜와 시간을 저장한다. 이 열은 NULL 값을 허용하지 않으며, 디폴트 값은 현재 날짜와 시간(GETDATE())이다.
