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





### 개발 진행 상황

#### ~~User API~~ (완료)

수정 필요한 사항 있으면 요청할 것

#### ~~Score API~~ (완료. 사실 개판임 오류있을 가능성 있음)

~~score update 가 되지 않는 상태. 새로운 데이터로만 들어간다. 수정 필요.~~

score update 개발 완료

user_rank 개발 완료



#### World API



#### Achievement API
