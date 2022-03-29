# ReadMe

### 실행을 위해 해야하는 설정

#### .NET 관련

visual studio installer 에서 .NET 추가 설치



#### MySql 관련

mysql workbench 설치 후, root 비밀번호 설정

프로젝트 폴더 내, `appsettings.json` 파일에서 아래코드를 workbench 설정대로 바꿔줄 것.

```json
{
    "ConnectionStrings": {
        "Default": "server=localhost;port=3306;database=onelineDB;user=root;password=[pw]"
    },
    ...
}
```

 (db는 워크벤치에 따로 생성해놓지 않아도 migration 돌리면 자동 생성됨)



#### migration

프로젝트 폴더 우클릭 터미널에서 열기

 `dotnet tool install --global dotnet-ef --version 5.0.1`

`dotnet ef database update`



#### 기본 데이터 생성

초기 기본데이터가 없는 상태일 것이기 때문에 아래 코드를 sql로 실행시켜서 기본 데이터를 생성해두고 테스트 해볼 것.

```sql
insert into onelinedb.users(UserId, UserPassword, UserName, UserContent, UserImg)
value
("string", "string", "string", "string", "string"),
("test", "1234", "테스트계정", "테스트를 위한 계정", "testimg");

insert into onelinedb.scores(UserId, WorldIdx, MyScore)
value
("test", 1, 50),
("string", 1, 80),
("test", 2, 5),
("string", 2, 10);

insert into onelinedb.worlds(WorldName, WorldContent, WorldScene, WorldCategory, WorldImg)
value
("카트레이싱", "카트레이싱 경쟁", 1, "게임", 1),
("점프킹", "점프 달리기 게임", 2, "게임", 2);



```





### 배포 전에 고쳐야 할 부분

Quest table 에 QuestIdx를 QeustIdx로 오타가 났다.

다른 부분 다 오타를 수정해야하긴 한데, AWS에 올린 DB에 마이그레이션 하기 전에 수정하고 올릴 것.



## 현재 프로젝트 진행 상황

백 : 거의 완성이긴 한데, 실 사용에서 오류가 얼마나 날지 몰라서 다른 파트에서 쓰면서 다시 체크해야함

프1 : 메인페이지 끝. 마이페이지 아마 오늘 내일 끝남. (API랑은 연결안함 - 감으로만 만들어놓고 있음) // 랭킹 페이지 개발 예정

프2 : 

유 - 실험 (60퍼 쯤) : 퀘스트, 서버 통신, 어드레서블 ( 에셋 번들 )

유 - 게임 () : 조금 문제임 예제 가져다가 하기로 했는데 코드를 몰라서 수정하기 애매함. 첫 코드에 포톤을 붙여야 하는데 좀 걸릴 거 같다.

프 - 유 붙이기

유니티 어드레서블 에셋 시스템



씬이나 오브젝트나 에셋 등을 하나의 파일처럼 뺀다. (확장자가 따로 있다.) - 서버위에  S3

웹에서 깡통 유니티를 올려놓고 함수 넣어놓고

거기서 내가 원하는 씬이 들어있는 파일을 S3에서 호출해온다.



메모리 줄여주고 필요한 거로 확장되기도 싶다.





작게 작게는 적용해봤는데 유니티가 아직 안만들어져서 다 합쳐서는 안해봄

그리고 리액트 네이티브에는 안해봤다



문제가 유니티 끝내고 리액트 네이티브로 돌아오는게 문제

