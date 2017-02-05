CREATE TABLE member (
	idkmitl INT PRIMARY KEY,
	name VARCHAR,
	nickname VARCHAR,
	faculty VARCHAR,
	park VARCHAR,
	room VARCHAR,
	phone VARCHAR,
	other VARCHAR
);

CREATE TABLE member_data(
	idkmitl INT REFERENCES member (idkmitl) ON DELETE CASCADE,
	username VARCHAR,
	password VARCHAR,
	stana INT
);

INSERT INTO member VALUES(12345678, 'god', 'god', 'วิศวกรรมศาสตร์', 'god', '-', 1234567890, 'god');
INSERT INTO member_data VALUES(12345678, 'god', 'god', 2);

CREATE TABLE reservation(
	id_res INTEGER PRIMARY KEY AUTOINCREMENT,
	idkmitl INT REFERENCES member (idkmitl) ON DELETE CASCADE,
	belong_to VARCHAR,
	project VARCHAR,
	loan_date VARCHAR,
	loan_date_time VARCHAR,
	returned_date VARCHAR,
	returned_date_time VARCHAR,
	licensor INT,
	type VARCHAR DEFAULT 'จอง',
	place VARCHAR,
	Timestamp DATETIME DEFAULT (DATETIME(CURRENT_TIMESTAMP, 'LOCALTIME'))
);

CREATE TABLE res_thing(
	id_res INT REFERENCES reservation (id_res) ON DELETE CASCADE,
	id_thing VARCHAR,
	num_thing INT
);

CREATE TABLE loaning(
	id_loan INTEGER PRIMARY KEY AUTOINCREMENT,
	idkmitl INT REFERENCES member (idkmitl) ON DELETE CASCADE,
	belong_to VARCHAR,
	project VARCHAR,
	loan_date VARCHAR,
	loan_date_time VARCHAR,
	returned_date VARCHAR,
	returned_date_time VARCHAR,
	licensor INT,
	type VARCHAR DEFAULT 'ยืม',
	place VARCHAR,
	card VARCHAR,
	Timestamp DATETIME DEFAULT (DATETIME(CURRENT_TIMESTAMP, 'LOCALTIME'))
);

CREATE TABLE loan_thing(
	id_loan INT REFERENCES loaning (id_loan) ON DELETE CASCADE,
	id_thing VARCHAR,
	num_thing INT
);


CREATE TABLE returned(
	id_return INTEGER PRIMARY KEY AUTOINCREMENT,
	idkmitl INT REFERENCES member (idkmitl) ON DELETE CASCADE,
	belong_to VARCHAR,
	project VARCHAR,
	loan_date VARCHAR,
	loan_date_time VARCHAR,
	returned_date VARCHAR,
	returned_date_time VARCHAR,
	licensor INT,
	type VARCHAR DEFAULT 'คืน',
	Timestamp DATETIME DEFAULT (DATETIME(CURRENT_TIMESTAMP, 'LOCALTIME'))
);

CREATE TABLE return_thing(
	id_return INT REFERENCES returned (id_return) ON DELETE CASCADE,
	id_thing VARCHAR,
	num_thing INT
);

CREATE TABLE thing(
	id_thing VARCHAR PRIMARY KEY,
	name_thing VARCHAR,
	all_thing INT,
	balance_thing INT,
	price DOUBLE,
	other
);



UPDATE thing SET balance_thing = (SELECT balance_thing FROM thing WHERE id_thing = @id_thing) - @num WHERE id_thing = @id_thing;





select r.id_thing, r.num_thing - IFNULL(l.num_thing, 0) as 'b'
from 
	(SELECT id_thing, sum(num_thing) as 'num_thing'
	FROM res_thing
	GROUP by id_thing) r

left outer join 
	(SELECT id_thing, sum(num_thing) as 'num_thing'
	FROM loan_thing
	GROUP by id_thing) l

on (r.id_thing = l.id_thing)


select a.idkmitl, a.id_loan, b.id_thing, sum(b.num_thing)
from loaning a
join loan_thing b
on (a.id_loan = b.id_loan)
group by a.idkmitl, b.id_thing;


select a.idkmitl, a.id_return, b.id_thing, sum(b.num_thing)
from  returned a
join return_thing b
on (a.id_return = b.id_return)
group by a.idkmitl, b.id_thing;



select x.idkmitl, x.id_thing, x.num - IFNULL(y.num, 0) as 'num'
from (select a.idkmitl, a.id_loan, b.id_thing, sum(b.num_thing) as 'num'
from loaning a
join loan_thing b
on (a.id_loan = b.id_loan)
group by a.idkmitl, b.id_thing) x
left outer join (select a.idkmitl, a.id_return, b.id_thing, sum(b.num_thing) as 'num'
from  returned a
join return_thing b
on (a.id_return = b.id_return)
group by a.idkmitl, b.id_thing) y
ON (x.idkmitl = y.idkmitl)
group by x.idkmitl, x.id_thing








ควรจะunix member_data idkmitl

UPDATE thing SET name_thing = @name_thing, balance_thing = (SELECT balance_thing FROM thing WHERE id_thing = @id_thing) - ((SELECT all_thing FROM thing WHERE id_thing = @id_thing) - @all_thing), all_thing = @all_thing, price = @price, other = @other WHERE id_thing = @id_thing;

50 20

50-60 = -10
50-40 = 10

20-(-10) = 30
20-(10) = 10



            SELECT id_res FROM reservation ORDER BY id_res DESC LIMIT 1;



select x.*, y.*, x.num - IFNULL(y.num, 0) as 'num2'
from
(
select a.idkmitl, a.id_loan, b.id_thing, sum(b.num_thing) as 'num'
from loaning a
join loan_thing b
on (a.id_loan = b.id_loan)
group by a.idkmitl, b.id_thing
) x
left outer join 
(
select a.idkmitl, a.id_return, b.id_thing, sum(b.num_thing) as 'num'
from  returned a
join return_thing b
on (a.id_return = b.id_return)
group by a.idkmitl, b.id_thing
) y

ON x.idkmitl = y.idkmitl AND x.id_thing = y.id_thing



                    if (check_return_end(Int32.Parse(inout_IdKmitl.Text)))
                    {

                    }
                    else
                    {
                        find_project_last(inout_IdKmitl.Text);
                    }
                


                select q.idkmitl AS 'รหัสนักศึกษา', q.belong_to AS 'สังกัด', q.project AS 'งาน',q.place AS 'สถานที่จัด', q.card AS 'ช่องใส่บัตร' , q.loan_date || ' ' ||q.loan_date_time AS 'วันที่ยืม', q.returned_date || ' '  || q.returned_date_time AS 'วันที่คืน' ,q.licensor AS 'ผู้อนุญาติ', q.type AS 'type',q.id_thing, q.num , w.*
from
(
select x.*, y.*, x.num - IFNULL(y.num, 0) as 'num2'
from
(
select a.*, b.id_thing, sum(b.num_thing) as 'num'
from loaning a
join loan_thing b
on (a.id_loan = b.id_loan)
group by a.idkmitl, b.id_thing
) x
left outer join 
(
select a.*, b.id_thing, sum(b.num_thing) as 'num'
from  returned a
join return_thing b
on (a.id_return = b.id_return)
group by a.idkmitl, b.id_thing
) y

ON x.idkmitl = y.idkmitl AND x.id_thing = y.id_thing
) q
join member w
on (q.idkmitl = w.idkmitl)
            

            select replace(replace(replace(IFNULL(m2.stana, 0), 0, 'Member'), 1, 'Admin'), 2, 'God') AS 'ประเภท', m.idkmitl AS 'รหัส นศ.', SUBSTR(m.name, 0, instr(m.name, ' ')) AS 'ชื่อ', substr(m.name, instr(m.name, ' ')) AS 'นามสกุล', m.nickname AS 'ชื่อเล่น', m.faculty AS 'คณะ', m.park AS 'ภาค', m.room AS 'ห้อง', m.phone AS 'เบอร์โทร'
from member m
left outer join member_data m2
on(m.idkmitl = m2.idkmitl)


alter table loaning add column time_stamp DATETIME DEFAULT CURRENT_TIMESTAMP
time_stamp DATETIME DEFAULT CURRENT_TIMESTAMP



select m.*, t.name_thing
from(
select a.*, b.id_thing, sum(b.num_thing) as 'num'
from reservation a
join res_thing b
on (a.id_res = b.id_res)
group by a.idkmitl, b.id_thing) m
join thing t
on m.id_thing = t.id_thing



select r.time_stamp,r.idkmitl, "" as card, th.name_thing, sum(rt.num_thing), r.licensor
from reservation r
join res_thing rt
on r.id_res = rt.id_res

join thing th
on rt.id_thing = th.id_thing
group by r.idkmitl, rt.id_thing
;


select r.time_stamp, "-" as card, m.nickname, m.room, m.park, r.belong_to,m.phone, th.name_thing || '=' || sum(rt.num_thing) as 'รายการที่ทำ', r.licensor
from reservation r
join res_thing rt
on r.id_res = rt.id_res

join thing th
on rt.id_thing = th.id_thing
join member m
on r.idkmitl = m.idkmitl
group by r.idkmitl, rt.id_thing
;

.................................................................
select time_stamp AS 'ว_ด_ป', card AS 'ช่องใส่บัตร', nickname AS 'ชื่อเล่น', room AS 'ห้อง', park AS 'ภาค', belong_to AS 'สังกัด', phone AS 'phone', type AS 'รายการที่ทำ', group_concat(tt, char(10)) AS 'รายการพัสดุ', place as 'สถานที่กิจกรรม',licensor AS 'ผู้รับทำรายการ'
from
(
select r.place, r.idkmitl, r.time_stamp, '-' as card, m.nickname, m.room, m.park, r.belong_to,m.phone, th.name_thing || '=' || sum(rt.num_thing)as 'tt', r.licensor, r.type
from reservation r
join res_thing rt
on r.id_res = rt.id_res
join thing th
on rt.id_thing = th.id_thing
join member m
on r.idkmitl = m.idkmitl
group by r.idkmitl, rt.id_thing
)
group by idkmitl

union

select time_stamp AS 'ว_ด_ป', card AS 'ช่องใส่บัตร', nickname AS 'ชื่อเล่น', room AS 'ห้อง', park AS 'ภาค', belong_to AS 'สังกัด', phone AS 'phone', type AS 'รายการที่ทำ', group_concat(tt, char(10)) AS 'รายการพัสดุ', place as 'สถานที่กิจกรรม', licensor AS 'ผู้รับทำรายการ'
from
(
select r.place, r.idkmitl, r.time_stamp, card as card, m.nickname, m.room, m.park, r.belong_to,m.phone, th.name_thing || '=' || sum(rt.num_thing)as 'tt', r.licensor, r.type
from loaning r
join loan_thing rt
on r.id_loan = rt.id_loan
join thing th
on rt.id_thing = th.id_thing
join member m
on r.idkmitl = m.idkmitl
group by r.idkmitl, rt.id_thing
)
group by idkmitl

union

select time_stamp AS 'ว_ด_ป', card AS 'ช่องใส่บัตร', nickname AS 'ชื่อเล่น', room AS 'ห้อง', park AS 'ภาค', belong_to AS 'สังกัด', phone AS 'เบอร์โทร', type AS 'รายการที่ทำ', group_concat(tt, char(10)) AS 'รายการพัสดุ', place as 'สถานที่กิจกรรม', licensor AS 'ผู้รับทำรายการ'
from
(
select '-' as place, r.idkmitl, r.time_stamp, '-' as card, m.nickname, m.room, m.park, r.belong_to,m.phone, th.name_thing || '=' || sum(rt.num_thing)as 'tt', r.licensor, r.type
from returned r
join return_thing rt
on r.id_return = rt.id_return
join thing th
on rt.id_thing = th.id_thing
join member m
on r.idkmitl = m.idkmitl
group by r.idkmitl, rt.id_thing
)
group by idkmitl
///////
select time_stamp AS 'ว_ด_ป', card AS 'ช่องใส่บัตร', nickname AS 'ชื่อเล่น', room AS 'ห้อง', park AS 'ภาค', belong_to AS 'สังกัด', project AS 'งาน', phone AS 'phone', type AS 'รายการที่ทำ', group_concat(tt, char(10)) AS 'รายการพัสดุ', place as 'สถานที่กิจกรรม', licensor AS 'ผู้รับทำรายการ'
from
(
select r.project, r.place, r.idkmitl, r.time_stamp, card as card, m.nickname, m.room, m.park, r.belong_to,m.phone, th.name_thing || '=' || sum(rt.num_thing)as 'tt', r.licensor, r.type
from loaning r
join loan_thing rt
on r.id_loan = rt.id_loan
join thing th
on rt.id_thing = th.id_thing
join member m
on r.idkmitl = m.idkmitl
group by r.idkmitl, rt.id_thing
)
group by idkmitl

union

select time_stamp AS 'ว_ด_ป', card AS 'ช่องใส่บัตร', nickname AS 'ชื่อเล่น', room AS 'ห้อง', park AS 'ภาค', belong_to AS 'สังกัด', project, phone AS 'phone', type AS 'รายการที่ทำ', group_concat(tt, char(10)) AS 'รายการพัสดุ', place as 'สถานที่กิจกรรม', licensor AS 'ผู้รับทำรายการ'
from
(
select r.project, '-' as place, r.idkmitl, r.time_stamp, '-' as card, m.nickname, m.room, m.park, r.belong_to,m.phone, th.name_thing || '=' || sum(rt.num_thing)as 'tt', r.licensor, r.type
from returned r
join return_thing rt
on r.id_return = rt.id_return
join thing th
on rt.id_thing = th.id_thing
join member m
on r.idkmitl = m.idkmitl
group by r.idkmitl, rt.id_thing
)
group by idkmitl

//////////////////////////////
select time_stamp AS 'ว_ด_ป', loan_date AS 'วันที่ยืม', returned_date AS 'วันที่คืน', nickname AS 'ชื่อเล่น', room AS 'ห้อง', park AS 'ภาค', belong_to AS 'สังกัด', project AS 'งาน', phone AS 'เบอร์โทร', type AS 'รายการที่ทำ', group_concat(tt, char(10)) AS 'รายการพัสดุ', place as 'สถานที่กิจกรรม',licensor AS 'ผู้รับทำรายการ'
from
(
select r.project, r.loan_date || ' ' || r.loan_date_time AS 'loan_date',r.returned_date || ' ' || r.returned_date_time AS 'returned_date', r.id_res, r.place, r.idkmitl, r.time_stamp, m.nickname, m.room, m.park, r.belong_to,m.phone, th.name_thing || '=' || sum(rt.num_thing)as 'tt', r.licensor, r.type
from reservation r
join res_thing rt
on r.id_res = rt.id_res
join thing th
on rt.id_thing = th.id_thing
join member m
on r.idkmitl = m.idkmitl
group by r.idkmitl, rt.id_thing, r.id_res
)
group by idkmitl, id_res