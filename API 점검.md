# API 점검

**<span style="color:red">이상 있음</span>**

**<span style="color:green">이상 없음</span>**

**<span style="color:orange">확인 요망</span>**

## User

### <span style="color:green">api/User/Login</span>

1. ~~아이디 있는데 pw 다를때~~
2. ~~아이디 있고 pw 같을 때 (성공)~~
3. ~~아이디 없을 때~~

### <span style="color:green">api/User/Join</span>

1. ~~샘플 아이디 정상 가입됨.~~
2. ~~중복 아이디 가입 체크 필요~~

### <span style="color:green">api/User/Check</span>

### <span style="color:green">api/User/{userid}</span>



## World

### <span style="color:green">api/World/{WorldIdx}</span>

1. 비밀번호 다르게 입력했는데 id not exist가 뜬다.

2. 맞게 입력해도 id not exist가 뜬다.

### <span style="color:green">api/World</span>

1. GET 방식인데 POST로 만들어뒀었음. 수정해서 재 배포함



## Achievement

### <span style="color:green">api/Achievement/Register</span>

1. ~~정상 입력 - 통과~~
2. ~~없는 월드인덱스 - `500 Internal Server Error` 아무 출력없음. 결과 출력 되도록 수정필요~~
3. ~~없는 quest인덱스 - 성공했다고 출력됨ㅡㅡ. 다행히 db에는 추가되지는 않음~~
4. ~~없는 ID -  `500 Internal Server Error` 아무 출력없음. 결과 출력 되도록 수정필요~~
5. ~~이미 완료한 퀘스트의 경우~~
6. ~~월드와 퀘스트가 내역이 맞지 않는 경우~~

### <span style="color:green">api/Achievement/Quest</span>

1. ~~정상 입력 - 통과~~
2. ~~없는 월드 인덱스 - 200 ok가 뜨고, 빈 llist가 출력됨 잘못됨.~~
3. ~~없는 아이디 - 모든 퀘스트 정보가 출력됨. 잘못됨.~~
4. ~~전체 퀘스트 다 완료 시 출력 방식 확인~~

### <span style="color:green">api/Achievement/{userid}</span>

1. ~~정상 get 통과~~
2. ~~없는 아이디로 get - 빈 list로 결과가 출력됨~~

## Score

### <span style="color:green">api/Score/Register</span>

1. ~~정상입력 성공~~
2. ~~없는 월드인덱스 -  `500 Internal Server Error` 아무 출력없음. 결과 출력 되도록 수정필요~~
3. ~~없는 id -  `500 Internal Server Error` 아무 출력없음. 결과 출력 되도록 수정필요~~

### <span style="color:green">api/Score/{userid}</span>

1. ~~서연이 요청대로 name 넣어서 출력 변경필요~~
2. ~~정상입력 성공~~
3. ~~없는 id - 비어 있는 list 출력~~
4. ~~랭킹에 1st -> first로 변경~~





status code 일관성 있게 수정

201 - Success

311 - User not exist

312 - World not exist

313 - Quest not exist

314 - Already finish this quest

315 - Quest - World not matched

316 - No score data

317 - Id already exist

318 - PW not matched