# Pizza Order Application 🍕

Ez egy **WPF (Windows Presentation Foundation)** alkalmazás, amely lehetővé teszi a felhasználók számára, hogy pizzákat válasszanak és rendeljenek, valamint egyedi feltéteket adjanak hozzá vagy módosítsanak egy külön szerkesztő ablakban.

## Funkciók ✨

- **Pizza kiválasztása:** 
  - A főablakban listázott pizzák közül választhat.
  - Minden pizza részletes leírást és árat tartalmaz.
  
- **Topping Editor (Feltét Szerkesztő):**
  - Egy külön ablakban szerkesztheted az adott pizzához tartozó feltéteket.
  - Új feltéteket adhatsz hozzá, meglévőket módosíthatsz vagy törölhetsz.
  
- **Rendelés összesítő:**
  - A kiválasztott pizzákat és feltéteket megjeleníti egy rendelési listában.
  - Automatikus árkalkuláció.

- **Egyszerű, letisztult UI:**
  - Könnyen kezelhető felhasználói felület, modern WPF dizájnnal.

## Felépítés 🛠️

Az alkalmazás két fő ablakból áll:
1. **Főablak**: A pizza kiválasztásához és a rendelés kezeléséhez.
2. **Szerkesztő ablak**: A feltétek hozzáadásához és módosításához.

A projekt alapvető WPF koncepciókat használ, mint például:
- **Adatbinding**
- **Eseménykezelés**
- **ObservableCollection** a dinamikus lista kezeléséhez

## Használat 🚀

1. Klónozd a repository-t:
   ```bash
   git clone https://github.com/felhasznalonev/pizza-order-app.git
