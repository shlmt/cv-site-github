# CV Site - GitHub API

## סקירה כללית
מיועד למפתחים המעוניינים להציג את תיק העבודות שלהם ב-GitHub בקליינט משלהם.

האפליקציה מתחברת לחשבון ה-GitHub של המשתמש, שולפת מידע על הפרויקטים שלו ומציגה נתונים רלוונטיים. בנוסף, היא מאפשרת חיפוש בכלל ה-repositories הפומביים עם אפשרויות סינון שונות.

## טכנולוגיות בשימוש
- **.NET Core Web API** – צד השרת.
- **Octokit.NET** – אינטגרציה עם API של GitHub.
- **Dependency Injection** – לשיפור מודולריות ותחזוקת הקוד.
- **Caching (In-Memory עם דפוס Decorator)** – לשיפור ביצועים.
- **Scrutor** – רישום תלויות אוטומטי עם דקורטורים.

- **ניהול תצורה וסודות (Secrets Management)** – לאבטחת נתוני הזדהות.

## נקודות קצה (API Endpoints)
### 1. שליפת תיק העבודות (`GetPortfolio`)
**נתיב:** `GET /api/portfolio`
- שליפת רשימת ה-repositories של המשתמש.
- הצגת נתונים כגון:
  - שפות פיתוח בשימוש.
  - רשימת ה-topics.
  - תאריך ה-commit האחרון.
  - מספר הכוכבים שקיבל ה-repository.
  - מספר ה-pull requests וה-commits.
  - קישור לאתר הפרויקט (אם קיים).
  - קישור לפרויקט בגיטהאב.
- שימוש במנגנון **Caching** לשיפור ביצועים.

### 2. חיפוש repositories ציבוריים (`SearchRepositories`)
**נתיב:** `GET /api/search?name={repoName}&language={language}&user={username}`
- חיפוש repositories ציבוריים ב-GitHub.
- תמיכה במסננים:
  - שם repository.
  - שפת תכנות.
  - שם משתמש ב-GitHub.

## ארכיטקטורת הקוד
הפרויקט מחולק לשני חלקים עיקריים:
1. **שכבת השירות (Service Layer - Class Library)** אחראית לתקשורת עם GitHub דרך Octokit.
2. **שכבת ה-Web API** מספקת נקודות קצה (REST API).

## אבטחה וניהול אימות
- שימוש **ב-Token אישי (PAT) של GitHub** לקריאות API מאובטחות.
- שמירה מאובטחת של הנתונים באמצעות: **Secrets.json**.
- בפיתוח: שימוש **בדפוס Options Pattern** להזרקת הנתונים המאובטחים לService.

## שיפור ביצועים
- **שמירת נתונים בזיכרון (In-Memory Caching)** להפחתת קריאות ל-GitHub API.
- **ניקוי אוטומטי של ה-Cache** כל מספר דקות כדי להבטיח עדכניות הנתונים.


## משאבים נוספים
- [תיעוד Octokit.NET](https://octokitnet.readthedocs.io/en/latest)
- [מדריך יצירת Token ב-GitHub](https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/creating-a-personal-access-token)
- [מדריך לdecorator ו-scrutor](https://andrewlock.net/adding-decorated-classes-to-the-asp.net-core-di-container-using-scrutor))

--
