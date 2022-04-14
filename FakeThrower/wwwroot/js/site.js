const select = document.querySelector('select');
const allLang = ['en', 'lt', 'ru', 'by', 'uk'];

const langArr = {
    "Title": {
        "en": "Fake page",
        "ru": "Фейковая страница",
        "uk": "Фальшива сторінка",
    },
    "WelcomeText": {
        "en": "Welcome to FakeThrower!",
        "ru": "Добро пожаловать на Фейкомет!",
        "uk": "Ласкаво просимо на Фейкомет!",
    },
    "SelectRegion": {
        "en": "Select language and region:",
        "ru": "Выберите язык и регион:",
        "uk": "Виберіть мову та регіон:",
    },
    "Logo": {
        "en": "FakeThrower:",
        "ru": "Фейкомет:",
        "uk": "Фейкомет:",
    },
    "Footer": {
        "en": "© 2022 - FakeThrower -",
        "ru": "© 2022 - Фейкомет -",
        "uk": "© 2022 - Фейкомет - Слава Україні!",
    },
    "Home": {
        "en": "Home",
        "ru": "Домой",
        "uk": "Додому",
    },
    "Number": {
        "en": "Number",
        "ru": "Номер",
        "uk": "Номер",
    },
    "FIO": {
        "en": "Lastname and Firstname",
        "ru": "Фамилия и имя",
        "uk": "Прізвище та ім'я",
    },
    "Adress": {
        "en": "Adress",
        "ru": "Адрес",
        "uk": "Адреса",
    },
    "PhoneNumber": {
        "en": "Phone number",
        "ru": "Телефонный номер",
        "uk": "Телефонний номер",
    },

}

select.addEventListener('change',changeURLLanguage);

function changeURLLanguage() {
    let lang = select.value;
    location.href = window.location.href.substring(0, window.location.href.length - 2) + lang;
}

function changeLanguage() {
    let lang = window.location.href.substring(window.location.href.length - 2, window.location.href.length);
    console.log(lang);
    if (!allLang.includes(lang)) {
        location.href =  window.location.pathname + 'en';
        location.reload();
    }
    select.value = lang;
    document.querySelector('title').innerHTML = langArr['Title'][lang];
    for (let key in langArr) {
        let elem = document.querySelector(".lng-" + key);
        if (elem) {
            elem.innerHTML = langArr[key][lang];
        }
    }
}

changeLanguage();

