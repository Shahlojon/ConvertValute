// Дата
const updateTime = () => {
    const time = new Date().toLocaleTimeString();
    const date = new Date().toLocaleDateString();
    $('#currency-date').html(date);
    $('#currency-time').html(time);
};

// Получение данных о курсе валют
const getCurrency = async (currency) => {
    const prevDate = new Date(Date.now() - 8.64e+7).toISOString().split('T')[0];
    const currentDate = new Date().toISOString().split('T')[0];
    await fetch(
        `https://core2api.alif.tj/api/v1/currency/${currency}/${prevDate}`)
        .then(async (response) => {
            prev[currency] = await response.json();
        });
    return await fetch(
        `https://core2api.alif.tj/api/v1/currency/${currency}/${currentDate}`)
        .then(async (response) => {
            const data = await response.json();
            setCurrency(data, currency);
        });
}

// Для проверки роста или падения курса
const prev = {
    // usd:{
    //     buy_value: 0,
    //     sell_value: 400
    // },
    // eur: {
    //     buy_value: 400,
    // },
    // rub: {
    //
    //     sell_value: 0
    // }
};

// Стрелки падения или роста курса
const setArrows = (prev, next, curr, value) => {
    if (prev[curr]) {
        return +prev[curr][value] < +next[value] ? 'up' :
            +prev[curr][value] > +next[value] ? 'down' : '';
    }
    return '';
}

// Установка курсов
const setCurrency = (data, currency) => {
    $(`#${currency}BuyXazina`).html(data.buy_value).addClass(setArrows(prev, data, currency, 'buy_value'));
    $(`#${currency}SellXazina`).html(data.sell_value).addClass(setArrows(prev, data, currency, 'sell_value'));
    $(`#${currency}BuyIntiqol`).html(data.money_transfer_buy_value).addClass(setArrows(prev, data, currency, 'money_transfer_buy_value'));
    $(`#${currency}SellIntiqol`).html(data.money_transfer_trade_value).addClass(setArrows(prev, data, currency, 'money_transfer_trade_value'));
    $(`#${currency}Bmt`).html(data.nbt_value).addClass(setArrows(prev, data, currency, 'nbt_value'));
    // prev[currency] = data;
}

// Первый запрос
const currency = ['usd', 'eur', 'rub'];
currency.forEach(getCurrency);

// Обновление курсов
setInterval(() => {
    currency.forEach(getCurrency);
}, 600000);

// Обновление времени
setInterval(updateTime, 1000);
