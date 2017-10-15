--SQL Scripts
--GRANT ALL PRIVILEGES ON ALL TABLES IN SCHEMA public TO PUBLIC;

DROP TABLE public.student;

CREATE TABLE public.student(
studentid BIGSERIAL PRIMARY KEY,
lastname varchar(64) NOT NULL,
firstmidname varchar(64) NOT NULL,
enrollmentdate timestamp without time zone NOT NULL
);

DROP TABLE public.course; 

CREATE TABLE public.course(
courseid BIGSERIAL PRIMARY KEY,
title varchar(64) NOT NULL,
credits int NOT NULL
);

DROP TABLE public.enrollment; 

CREATE TABLE public.enrollment(
enrollmentid BIGSERIAL PRIMARY KEY,
courseid int NOT NULL,
studentid int NOT NULL,
grade int  NULL
);


SELECT * FROM public.student;
SELECT * FROM public.course;
SELECT * FROM public.enrollment;


