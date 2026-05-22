-- ============================================================
-- MerchandisingSystem — схема БД + тестовые данные
-- ============================================================

SET client_encoding = 'UTF8';

-- На случай повторного запуска — снести всё и пересоздать
DROP TABLE IF EXISTS task_reports   CASCADE;
DROP TABLE IF EXISTS route_points   CASCADE;
DROP TABLE IF EXISTS routes         CASCADE;
DROP TABLE IF EXISTS tasks          CASCADE;
DROP TABLE IF EXISTS stores         CASCADE;
DROP TABLE IF EXISTS merchandisers  CASCADE;
DROP TABLE IF EXISTS users          CASCADE;

-- ── users ────────────────────────────────────────────────────
CREATE TABLE users (
    id            SERIAL PRIMARY KEY,
    full_name     VARCHAR(100) NOT NULL,
    login         VARCHAR(50)  NOT NULL UNIQUE,
    password_hash VARCHAR(255) NOT NULL,
    role          VARCHAR(20)  NOT NULL    -- 'supervisor' | 'merchandiser'
);

-- ── merchandisers ────────────────────────────────────────────
CREATE TABLE merchandisers (
    id      SERIAL PRIMARY KEY,
    user_id INTEGER REFERENCES users(id),
    phone   VARCHAR(20)
);

-- ── stores ───────────────────────────────────────────────────
CREATE TABLE stores (
    id         SERIAL PRIMARY KEY,
    name       VARCHAR(100) NOT NULL,
    address    VARCHAR(255),
    latitude   DOUBLE PRECISION,
    longitude  DOUBLE PRECISION,
    store_type VARCHAR(50),
    comment    TEXT
);

-- ── tasks ────────────────────────────────────────────────────
CREATE TABLE tasks (
    id              SERIAL PRIMARY KEY,
    store_id        INTEGER REFERENCES stores(id),
    merchandiser_id INTEGER REFERENCES merchandisers(id),
    task_type       VARCHAR(50),
    description     TEXT,
    planned_date    DATE,
    status          VARCHAR(20) DEFAULT 'новая',
    created_at      TIMESTAMP DEFAULT NOW()
);

-- ── task_reports ─────────────────────────────────────────────
CREATE TABLE task_reports (
    id           SERIAL PRIMARY KEY,
    task_id      INTEGER REFERENCES tasks(id),
    comment      TEXT,
    completed_at TIMESTAMP,
    status       VARCHAR(20)
);

-- ── routes ───────────────────────────────────────────────────
CREATE TABLE routes (
    id              SERIAL PRIMARY KEY,
    merchandiser_id INTEGER REFERENCES merchandisers(id),
    route_date      DATE,
    status          VARCHAR(20)
);

-- ── route_points ─────────────────────────────────────────────
CREATE TABLE route_points (
    id          SERIAL PRIMARY KEY,
    route_id    INTEGER REFERENCES routes(id),
    store_id    INTEGER REFERENCES stores(id),
    point_order INTEGER
);

-- ============================================================
-- Тестовые данные
-- ============================================================

-- Пользователи
-- admin  / admin123   (роль supervisor)
-- merch1 / 123        (роль merchandiser)
INSERT INTO users (full_name, login, password_hash, role) VALUES
('Администратор', 'admin',  '$2a$11$.67vK3a5zmLAhxVZ6NKPFek8hTbS2qQuse9PGDmO5vzKuyZtu/PMe', 'supervisor'),
('Иван Петров',   'merch1', '$2a$11$8Vw0XJ3qS2lF3jXQ1cKZ6e6kqVQGpQ6gWmOq3UqK3pZcF1m5o5jKy', 'merchandiser');

-- Мерчандайзер (привязан к users.id = 2 — Ивану)
INSERT INTO merchandisers (user_id, phone) VALUES
(2, '+7-900-000-00-01');

-- Торговые точки (Ростов-на-Дону)
INSERT INTO stores (name, address, latitude, longitude, store_type, comment) VALUES
('Магнит',         'Ростов-на-Дону, Будённовский, 49',  47.2249688, 39.7047548, 'гипермаркет', 'центр'),
('Пятёрочка',      'Ростов-на-Дону, Большая Садовая, 76', 47.2225,    39.7188,    'супермаркет', ''),
('Перекрёсток',    'Ростов-на-Дону, Текучёва, 246',     47.2390,    39.7250,    'супермаркет', ''),
('Лента',          'Ростов-на-Дону, Малиновского, 25',  47.2580,    39.6420,    'гипермаркет', ''),
('Ашан',           'Ростов-на-Дону, Малиновского, 25Б', 47.2585,    39.6430,    'гипермаркет', '');

-- Задачи
INSERT INTO tasks (store_id, merchandiser_id, task_type, description, planned_date, status) VALUES
(1, 1, 'проверка выкладки товара', 'Проверить полку с напитками', CURRENT_DATE,            'новая'),
(2, 1, 'проверка ценников',         'Сверить ценники на акционных товарах', CURRENT_DATE + 1, 'в работе'),
(3, 1, 'фотоотчет',                  'Сделать фото витрин', CURRENT_DATE - 1, 'выполнена');
