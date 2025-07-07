
```markdown
# 🧠 Console Task Manager – Projet .NET en C#

Bienvenue dans **Console Task Manager**, une application console en C# développée avec .NET, permettant la gestion complète de vos tâches personnelles (et sous-tâches) dans un environnement simple, structuré et modulaire.

---

## 🚀 Fonctionnalités

✅ Interface en ligne de commande intuitive  
✅ Création, modification, suppression de tâches  
✅ Prise en charge des sous-tâches imbriquées  
✅ Navigation récursive (retour automatique au menu principal)  
✅ Architecture propre en MVC  
✅ Couche d’abstraction pour faciliter les tests  
✅ Vérification de saisie (noms vides, entrées invalides, etc.)  
✅ Système de sélection de tâche avec confirmation  
✅ Persistance à venir : **sauvegarde et chargement via SQLite**

---

## 📸 Aperçu

```

\===== Task Tracker =====

1. View All Tasks
2. Create New Task
3. Delete a Task
4. Select Task
5. Exit

> 2

\===== Create a task =====
Enter a task name (Mandatory): My first task
Enter a description of your task (Optional): Test the task manager

Task added successfully!

````

---

## 🧱 Architecture

Le projet est découpé selon les principes **MVC** :

- **Model** : `TaskItem`, `ITaskItem`, etc. – classes métier
- **View** : Interfaces utilisateurs `ViewTaskManager`, `IUserInterface`, `ConsoleUI`
- **Controller** : Gère la logique et les entrées utilisateur
- **Infrastructure** : UI simulée pour tests (`MockUserInterface`)
- **Tests** : Tests unitaires pour la logique métier et interface

---

## 🧪 Tests

Des tests sont en place pour :

- ✅ La validation des noms de tâche
- ✅ L’affichage correct de la liste
- ✅ L’impossibilité de créer une tâche vide
- ✅ La suppression sécurisée avec confirmation utilisateur

---

## 📂 Structure

```bash
ConsoleTaskManager/
│
├── Models/
│   └── TaskItem.cs
│
├── Views/
│   └── ViewTaskManager.cs
│
├── Controllers/
│   └── TaskController.cs
│
├── Interfaces/
│   ├── ITaskItem.cs
│   ├── IUserInterface.cs
│
├── Infrastructure/
│   ├── ConsoleUI.cs
│   └── MockUserInterface.cs
│
├── Tests/
│   └── TaskManagerTests.cs
│
└── Program.cs
````

---

## 🔧 Prochaines évolutions

* 💾 Sauvegarde automatique en **base SQLite**
* 👤 Système d’authentification (Login / Register)
* 🖼️ Interface graphique avec **WinForms** ou **WPF**
* 📂 Export/Import des tâches
* 🌐 Passage en WebApp ou en launcher intégré à Unity (étude en cours)

---

## 📚 Prérequis

* [.NET 8 SDK](https://dotnet.microsoft.com/download)
* Visual Studio ou VS Code
* (Optionnel) xUnit pour les tests unitaires

---

## ▶️ Lancer le projet

```bash
git clone https://github.com/votre-utilisateur/ConsoleTaskManager.git
cd ConsoleTaskManager
dotnet run
```

---

## 🤝 Contribuer

Les suggestions, retours, étoiles ⭐ ou pull requests sont les bienvenus ! Ce projet est un terrain d'apprentissage, toute aide est précieuse.

---

## 📜 Licence

Ce projet est sous licence MIT – libre à vous de l’adapter, l’utiliser et le partager.

---

## ✨ Auteur

Développé avec ❤️ par **\[Votre prénom Nom]**
📫 Contact : \[[email@exemple.com](mailto:email@exemple.com)]
🌐 Portfolio / LinkedIn : \[ajoutez ici]

```

---

Souhaitez-tu aussi que je t’aide à rédiger un petit `CONTRIBUTING.md` ou un `LICENSE` ?

Et dès que tu me donnes ton lien GitHub, je peux même t’aider à le formater dans le README.
```
