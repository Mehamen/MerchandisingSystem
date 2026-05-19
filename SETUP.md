# Установка проекта на новом ноутбуке

## 0. Что понадобится
- Windows 10/11 (x64) с правами администратора
- ~10 ГБ свободного места
- Интернет

---

## 1. Загрузка проекта в Git (со старого ноута)

В корне `D:\for_me\MerchandisingSystem` (там, где лежит `.sln`):

```powershell
git init
git add .
git commit -m "Initial commit: MerchandisingSystem"
```

Создай пустой репозиторий на GitHub (без README/gitignore), скопируй его URL и:

```powershell
git branch -M main
git remote add origin https://github.com/<твой-логин>/MerchandisingSystem.git
git push -u origin main
```

---

## 2. Установка WSL2 (на новом ноуте)

Открой **PowerShell от имени администратора**:

```powershell
wsl --install
```

Эта одна команда:
- включит компоненты `VirtualMachinePlatform` и `Microsoft-Windows-Subsystem-Linux`,
- скачает ядро WSL2,
- поставит Ubuntu по умолчанию.

После окончания **перезагрузи компьютер**.

После перезагрузки Ubuntu запустится сама и попросит создать пользователя/пароль — придумай любые.

Проверь, что всё ок:
```powershell
wsl --status
wsl --list --verbose
```
В колонке `VERSION` должно стоять **2**.

Если по какой-то причине стоит версия 1 — выполни:
```powershell
wsl --set-default-version 2
```

---

## 3. Установка Docker Desktop

1. Скачай с https://www.docker.com/products/docker-desktop/
2. Запусти установщик, на экране выбора компонентов оставь галку **«Use WSL 2 instead of Hyper-V»**.
3. Перезагрузись, если попросит.
4. Запусти Docker Desktop → дождись, когда индикатор в трее станет зелёным.
5. Открой Settings → Resources → WSL Integration → включи интеграцию с Ubuntu.

Проверка в PowerShell:
```powershell
docker --version
docker compose version
docker run --rm hello-world
```

---

## 4. Клонирование проекта

```powershell
cd D:\
mkdir for_me
cd for_me
git clone https://github.com/<твой-логин>/MerchandisingSystem.git
cd MerchandisingSystem
```

В репозитории должны быть, в числе прочего:
- `docker-compose.yml`
- `init.sql` — дамп схемы и данных PostgreSQL
- `MerchandisingSystem.sln`

---

## 5. Поднимаем PostgreSQL в Docker

В папке проекта (там, где `docker-compose.yml`):

```powershell
docker compose up -d
```

Что произойдёт:
- Docker скачает образ `postgres:16`.
- Создаст контейнер `merch_pg`.
- Создаст БД `merchandising` с пользователем `postgres` / паролем `S1t2e3.!`.
- **При первом запуске** автоматически выполнит `init.sql` (там и схема, и данные).
- Прокинет порт `5432` наружу — приложение сможет подключаться как обычно к `localhost:5432`.

Проверка:
```powershell
docker ps
docker logs merch_pg --tail 30
```

В логах должна быть строка `database system is ready to accept connections`.

Зайти в psql внутри контейнера:
```powershell
docker exec -it merch_pg psql -U postgres -d merchandising
```
Дальше можно делать `\dt` (список таблиц), `SELECT * FROM users;` и т. д. Выход: `\q`.

---

## 6. Запуск приложения

1. Открой `MerchandisingSystem.sln` в Visual Studio 2022.
2. **Восстанови NuGet-пакеты**: правый клик по решению → *Restore NuGet Packages* (или они подтянутся сами при сборке).
3. Жми `F5` — приложение само подключится к PostgreSQL внутри Docker (строка подключения в `Database.cs` указывает на `localhost:5432`).

---

## 7. Полезные команды Docker

| Действие | Команда |
|---|---|
| Запустить | `docker compose up -d` |
| Остановить | `docker compose stop` |
| Остановить + удалить контейнер (данные останутся) | `docker compose down` |
| Полный сброс БД (УДАЛИТ ВСЕ ДАННЫЕ, init.sql выполнится заново) | `docker compose down -v` затем `docker compose up -d` |
| Логи | `docker logs merch_pg -f` |
| Войти в psql | `docker exec -it merch_pg psql -U postgres -d merchandising` |
| Сделать дамп БД | `docker exec merch_pg pg_dump -U postgres merchandising > backup.sql` |

---

## 8. Если что-то пошло не так

**«Cannot connect to the Docker daemon»** — Docker Desktop не запущен. Открой его из меню Пуск.

**Порт 5432 занят** — на ноуте уже стоит локальный PostgreSQL. Останови службу:
```powershell
Stop-Service postgresql-x64-16   # или postgresql-x64-18
```
Или измени проброс портов в `docker-compose.yml` на `"5433:5432"` и поправь `Database.cs` (`Port=5433`).

**Кириллица в psql внутри контейнера выглядит как `???`** — это только проблема отрисовки в Windows-консоли, в самой БД данные хранятся в UTF-8 (в приложении они отобразятся правильно). Чтобы поправить отображение: `chcp 65001` в PowerShell перед `docker exec`.

**`init.sql` не выполнился** — он применяется только когда volume `pgdata` пустой. Сделай `docker compose down -v` и подними заново.
