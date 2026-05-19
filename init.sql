--
-- PostgreSQL database dump
--

-- restrict directive removed for cross-version compatibility

-- Dumped from database version 18.3
-- Dumped by pg_dump version 18.3

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: merchandisers; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.merchandisers (
    id integer NOT NULL,
    user_id integer,
    phone character varying(20)
);


--
-- Name: merchandisers_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.merchandisers_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: merchandisers_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.merchandisers_id_seq OWNED BY public.merchandisers.id;


--
-- Name: route_points; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.route_points (
    id integer NOT NULL,
    route_id integer,
    store_id integer,
    point_order integer
);


--
-- Name: route_points_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.route_points_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: route_points_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.route_points_id_seq OWNED BY public.route_points.id;


--
-- Name: routes; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.routes (
    id integer NOT NULL,
    merchandiser_id integer,
    route_date date,
    status character varying(20)
);


--
-- Name: routes_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.routes_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: routes_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.routes_id_seq OWNED BY public.routes.id;


--
-- Name: stores; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.stores (
    id integer NOT NULL,
    name character varying(100) NOT NULL,
    address character varying(255),
    latitude double precision,
    longitude double precision,
    store_type character varying(50),
    comment text
);


--
-- Name: stores_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.stores_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: stores_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.stores_id_seq OWNED BY public.stores.id;


--
-- Name: task_reports; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.task_reports (
    id integer NOT NULL,
    task_id integer,
    comment text,
    completed_at timestamp without time zone,
    status character varying(20)
);


--
-- Name: task_reports_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.task_reports_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: task_reports_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.task_reports_id_seq OWNED BY public.task_reports.id;


--
-- Name: tasks; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.tasks (
    id integer NOT NULL,
    store_id integer,
    merchandiser_id integer,
    task_type character varying(50),
    description text,
    planned_date date,
    status character varying(20) DEFAULT '­®ў п'::character varying,
    created_at timestamp without time zone DEFAULT now()
);


--
-- Name: tasks_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.tasks_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: tasks_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.tasks_id_seq OWNED BY public.tasks.id;


--
-- Name: users; Type: TABLE; Schema: public; Owner: -
--

CREATE TABLE public.users (
    id integer NOT NULL,
    full_name character varying(100) NOT NULL,
    login character varying(50) NOT NULL,
    password_hash character varying(255) NOT NULL,
    role character varying(20) NOT NULL
);


--
-- Name: users_id_seq; Type: SEQUENCE; Schema: public; Owner: -
--

CREATE SEQUENCE public.users_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


--
-- Name: users_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: -
--

ALTER SEQUENCE public.users_id_seq OWNED BY public.users.id;


--
-- Name: merchandisers id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.merchandisers ALTER COLUMN id SET DEFAULT nextval('public.merchandisers_id_seq'::regclass);


--
-- Name: route_points id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.route_points ALTER COLUMN id SET DEFAULT nextval('public.route_points_id_seq'::regclass);


--
-- Name: routes id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.routes ALTER COLUMN id SET DEFAULT nextval('public.routes_id_seq'::regclass);


--
-- Name: stores id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.stores ALTER COLUMN id SET DEFAULT nextval('public.stores_id_seq'::regclass);


--
-- Name: task_reports id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.task_reports ALTER COLUMN id SET DEFAULT nextval('public.task_reports_id_seq'::regclass);


--
-- Name: tasks id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.tasks ALTER COLUMN id SET DEFAULT nextval('public.tasks_id_seq'::regclass);


--
-- Name: users id; Type: DEFAULT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.users ALTER COLUMN id SET DEFAULT nextval('public.users_id_seq'::regclass);


--
-- Data for Name: merchandisers; Type: TABLE DATA; Schema: public; Owner: -
--

COPY public.merchandisers (id, user_id, phone) FROM stdin;
1	3	+7-900-000-00-01
2	3	+79000000001
3	3	+79000000001
\.


--
-- Data for Name: route_points; Type: TABLE DATA; Schema: public; Owner: -
--

COPY public.route_points (id, route_id, store_id, point_order) FROM stdin;
\.


--
-- Data for Name: routes; Type: TABLE DATA; Schema: public; Owner: -
--

COPY public.routes (id, merchandiser_id, route_date, status) FROM stdin;
\.


--
-- Data for Name: stores; Type: TABLE DATA; Schema: public; Owner: -
--

COPY public.stores (id, name, address, latitude, longitude, store_type, comment) FROM stdin;
1	Ренна-Северный	Ленточная	47.2386346925758	39.6382030230602	супермаркет	ооооаоааааа
2	Дом	Ростов-на-Дону, Вятская, 63/2	47.2813292	39.7651101	магазин	
3	Магнит	Ростов-на-Дону, Будённовский, 49	47.2249688	39.7047548	гипермаркет	ффы
\.


--
-- Data for Name: task_reports; Type: TABLE DATA; Schema: public; Owner: -
--

COPY public.task_reports (id, task_id, comment, completed_at, status) FROM stdin;
\.


--
-- Data for Name: tasks; Type: TABLE DATA; Schema: public; Owner: -
--

COPY public.tasks (id, store_id, merchandiser_id, task_type, description, planned_date, status, created_at) FROM stdin;
1	1	1	фотоотчет	asdad	2026-05-16	выполнена	2026-05-15 23:26:53.517671
\.


--
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: -
--

COPY public.users (id, full_name, login, password_hash, role) FROM stdin;
3	Иван Петров	merch1		merchandiser
2	Администратор	admin	$2a$11$.67vK3a5zmLAhxVZ6NKPFek8hTbS2qQuse9PGDmO5vzKuyZtu/PMe	supervisor
\.


--
-- Name: merchandisers_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.merchandisers_id_seq', 3, true);


--
-- Name: route_points_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.route_points_id_seq', 1, false);


--
-- Name: routes_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.routes_id_seq', 1, false);


--
-- Name: stores_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.stores_id_seq', 3, true);


--
-- Name: task_reports_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.task_reports_id_seq', 1, false);


--
-- Name: tasks_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.tasks_id_seq', 1, true);


--
-- Name: users_id_seq; Type: SEQUENCE SET; Schema: public; Owner: -
--

SELECT pg_catalog.setval('public.users_id_seq', 4, true);


--
-- Name: merchandisers merchandisers_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.merchandisers
    ADD CONSTRAINT merchandisers_pkey PRIMARY KEY (id);


--
-- Name: route_points route_points_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.route_points
    ADD CONSTRAINT route_points_pkey PRIMARY KEY (id);


--
-- Name: routes routes_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.routes
    ADD CONSTRAINT routes_pkey PRIMARY KEY (id);


--
-- Name: stores stores_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.stores
    ADD CONSTRAINT stores_pkey PRIMARY KEY (id);


--
-- Name: task_reports task_reports_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.task_reports
    ADD CONSTRAINT task_reports_pkey PRIMARY KEY (id);


--
-- Name: tasks tasks_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.tasks
    ADD CONSTRAINT tasks_pkey PRIMARY KEY (id);


--
-- Name: users users_login_key; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_login_key UNIQUE (login);


--
-- Name: users users_pkey; Type: CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (id);


--
-- Name: merchandisers merchandisers_user_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.merchandisers
    ADD CONSTRAINT merchandisers_user_id_fkey FOREIGN KEY (user_id) REFERENCES public.users(id);


--
-- Name: route_points route_points_route_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.route_points
    ADD CONSTRAINT route_points_route_id_fkey FOREIGN KEY (route_id) REFERENCES public.routes(id);


--
-- Name: route_points route_points_store_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.route_points
    ADD CONSTRAINT route_points_store_id_fkey FOREIGN KEY (store_id) REFERENCES public.stores(id);


--
-- Name: routes routes_merchandiser_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.routes
    ADD CONSTRAINT routes_merchandiser_id_fkey FOREIGN KEY (merchandiser_id) REFERENCES public.merchandisers(id);


--
-- Name: task_reports task_reports_task_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.task_reports
    ADD CONSTRAINT task_reports_task_id_fkey FOREIGN KEY (task_id) REFERENCES public.tasks(id);


--
-- Name: tasks tasks_merchandiser_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.tasks
    ADD CONSTRAINT tasks_merchandiser_id_fkey FOREIGN KEY (merchandiser_id) REFERENCES public.merchandisers(id);


--
-- Name: tasks tasks_store_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: -
--

ALTER TABLE ONLY public.tasks
    ADD CONSTRAINT tasks_store_id_fkey FOREIGN KEY (store_id) REFERENCES public.stores(id);


--
-- PostgreSQL database dump complete
--

-- unrestrict directive removed

