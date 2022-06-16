// Дата
const updateTime = () => {
    const time = new Date().toLocaleTimeString();
    const date = new Date().toLocaleDateString();
    $('#currency-date').html(date);
    $('#currency-time').html(time);
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
    $(`#${currency}BuyXazina`).html(data.buy_value.toFixed(4)).addClass(setArrows(prev, data, currency, 'buy_value'));
    $(`#${currency}SellXazina`).html(data.sell_value.toFixed(4)).addClass(setArrows(prev, data, currency, 'sell_value'));
    $(`#${currency}BuyIntiqol`).html(data.money_transfer_buy_value.toFixed(4)).addClass(setArrows(prev, data, currency, 'money_transfer_buy_value'));
    $(`#${currency}SellIntiqol`).html(data.money_transfer_trade_value.toFixed(4)).addClass(setArrows(prev, data, currency, 'money_transfer_trade_value'));
    $(`#${currency}Bmt`).html(data.nbt_value.toFixed(4)).addClass(setArrows(prev, data, currency, 'nbt_value'));
    // prev[currency] = data;
}

// Обновление времени
setInterval(updateTime, 1000);
