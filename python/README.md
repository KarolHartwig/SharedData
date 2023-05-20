# Instrukcja uruchamiania projektu Django i migracji

Aby uruchomić projekt Django i przeprowadzić migracje, postępuj zgodnie z poniższymi krokami:

## Kroki przed uruchomieniem projektu
1. Upewnij się, że masz zainstalowanego Pythona (w wersji zgodnej z wymaganiami projektu) oraz narzędzie `pip` do zarządzania pakietami.

## Kroki uruchomienia projektu
1. Sklonuj repozytorium projektu Django na swój lokalny komputer:
`git clone https://github.com/gracjan-katek/np-projekt.git`
3. Przejdź do katalogu projektu: 
`cd np-projekt`
3. Utwórz i aktywuj wirtualne środowisko Pythona (zalecane, ale nieobowiązkowe):
```
python3 -m venv myenv # Tworzenie wirtualnego środowiska
source myenv/bin/activate # Aktywowanie wirtualnego środowiska
```
4. Zainstaluj zależności projektu, korzystając z pliku requirements.txt: 
`pip install -r requirements.txt`
5. Przeprowadź migracje bazy danych:
```
python manage.py makemigrations
python manage.py migrate
```
6. Uruchom serwer deweloperski Django:
`python manage.py runserver`

Po uruchomieniu, aplikacja będzie dostępna pod adresem `http://localhost:8000/`.

**Uwaga:** W przypadku, gdy port 8000 jest już zajęty na twoim komputerze, możesz określić inny port poprzez dodanie jego numeru po komendzie `runserver`, np. `python manage.py runserver 8080`.

Upewnij się, że masz wszystkie wymagane zależności zainstalowane, a także dostęp do odpowiedniej bazy danych (jeśli jest wymagana) przed rozpoczęciem. W przypadku uruchomienia testowego w pliku `np-projekt/settings.py`
należy zmienić sekcję 
```
DATABASES = {
    'default': {
        'ENGINE': 'django.db.backends.postgresql',
        'NAME': 'np_projekt',
        'USER': 'np_user',
        'PASSWORD': 'np_passwd',
        'HOST': '127.0.0.1',
        'PORT': '32771',
    }
}
```
na 
```
DATABASES = {
'default': {
         'ENGINE': 'django.db.backends.sqlite3',
         'NAME': os.path.join(BASE_DIR, 'db.sqlite3'),
     }
}
```





