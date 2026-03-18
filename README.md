# Unity Addressables — учебный проект

> **Курс:** [otus.ru](https://otus.ru) — Разработка игр на Unity  
> **Тема:** Загрузка ресурсов с помощью Addressables

---

## 📖 О проекте

Небольшая 3D-сцена, демонстрирующая практическое использование **Unity Addressables** — системы адресуемых ресурсов, позволяющей загружать сцены и ассеты асинхронно, не удерживая их в памяти без необходимости.

Персонаж перемещается по локации, и при входе в триггерную зону динамически загружается дополнительный участок мира. При выходе из зоны ресурс освобождается. Загрузка игровой сцены из главного меню также выполняется через Addressables.

---

## ✨ Что реализовано

| Возможность | Описание |
|---|---|
| **Асинхронная загрузка сцены** | `Addressables.LoadSceneAsync()` при переходе из главного меню в игру |
| **Динамическая загрузка ассетов** | `Addressables.LoadAssetAsync<GameObject>()` при входе персонажа в коллайдер-триггер |
| **Корректное освобождение памяти** | `Addressables.Release()` вызывается при отключении объекта |
| **Пауза** | Экран паузы с возвратом в главное меню |
| **Движение персонажа** | Управление с клавиатуры (WASD), управляемая камера |

---

## 🛠 Технологии

| Технология | Версия | Назначение |
|---|---|---|
| **Unity** | 2022.3 LTS | Игровой движок |
| **Unity Addressables** | 1.21.20 | Управление ресурсами и их адресная загрузка |
| **Universal Render Pipeline (URP)** | 14.0.8 | Рендеринг |
| **Zenject** | — | Dependency Injection (IoC-контейнер) |
| **TextMesh Pro** | 3.0.6 | Текст в UI |
| **C#** | — | Язык разработки |

---

## 🏗 Архитектура

Проект разделён на слои:

```
Assets/Game/Scripts/
├── Application/          # Точка входа: загрузка сцен, Zenject-инсталлер
│   ├── GameLoader.cs     # Загружает Game-сцену через Addressables (async)
│   ├── MenuLoader.cs     # Загружает Menu-сцену стандартным SceneManager
│   ├── ApplicationExiter.cs
│   └── Installers/
│       └── ProjectInstaller.cs  # Корневой Zenject-инсталлер
├── Gameplay/             # Игровая логика
│   ├── Objects/
│   │   └── Character.cs  # MonoBehaviour персонажа (ICharacter)
│   ├── Systems/
│   │   ├── MoveController.cs    # IFixedTickable — двигает персонажа
│   │   ├── MoveInput.cs         # Считывает ввод с клавиатуры
│   │   ├── CameraFollower.cs    # ILateTickable — следит за персонажем
│   │   ├── CameraConfig.cs
│   │   └── InputConfig.cs
│   └── Installers/
│       └── GameInstaller.cs    # Zenject-инсталлер игровой сцены
├── Locations/
│   └── TriggerController.cs    # Загружает ассеты через Addressables по триггеру
└── UI/
    ├── MenuScreen.cs / MenuScreenController.cs
    ├── PauseScreen.cs / PauseScreenController.cs
    └── PauseButton.cs
```

**Паттерны:** DI (Zenject), Interface Segregation, разделение логики и MonoBehaviour-компонентов.

---

## 🚀 Запуск проекта

1. Установите **Unity 2022.3 LTS** через [Unity Hub](https://unity.com/download).
2. Клонируйте репозиторий:
   ```bash
   git clone https://github.com/MrRandomise/Adressables.git
   ```
3. Откройте папку проекта в Unity Hub → **Open Project**.
4. Откройте сцену `Assets/Game/Scenes/Menu` и нажмите **Play**.

> **Примечание:** Перед сборкой убедитесь, что Addressables-группы собраны: `Window → Asset Management → Addressables → Groups → Build → New Build → Default Build Script`.

---

## 📚 Чему научился

- Настройке и использованию **Unity Addressables** (группы, метки, адреса).
- Асинхронной загрузке сцен (`LoadSceneAsync`) и ассетов (`LoadAssetAsync`).
- Правильному освобождению памяти через `Addressables.Release()`.
- Организации проекта с **Zenject** (Dependency Injection) и разделением на слои.
- Архитектурным паттернам: интерфейсы, инсталлеры, системы обновления (`IFixedTickable`, `ILateTickable`).
