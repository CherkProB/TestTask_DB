-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Сен 01 2023 г., 14:35
-- Версия сервера: 8.0.30
-- Версия PHP: 8.1.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `test_task`
--

-- --------------------------------------------------------

--
-- Структура таблицы `customers`
--

CREATE TABLE `customers` (
  `id_customer` int NOT NULL,
  `surname` varchar(50) DEFAULT NULL,
  `name` varchar(50) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `phone_number` double DEFAULT NULL
) ;

--
-- Дамп данных таблицы `customers`
--

INSERT INTO `customers` (`id_customer`, `surname`, `name`, `email`, `phone_number`) VALUES
(1, 'Ivanov', 'Ivan', 'Ivan@yandex.ru', 89995431010),
(2, 'Petrov', 'Petr', 'Petr@gmail.com', 89189990100),
(4, 'Sidorov', 'Oleg', 'Oleg@rgups.ru', 88009871010),
(5, 'Romanenko', 'Ivan', 'Rom@yandex.ru', 89991002030);

-- --------------------------------------------------------

--
-- Структура таблицы `orders`
--

CREATE TABLE `orders` (
  `id_order` int NOT NULL,
  `title` varchar(100) DEFAULT NULL,
  `order_date` date DEFAULT NULL,
  `order_price` int DEFAULT NULL,
  `id_customer` int NOT NULL
) ;

--
-- Дамп данных таблицы `orders`
--

INSERT INTO `orders` (`id_order`, `title`, `order_date`, `order_price`, `id_customer`) VALUES
(1, 'Order1', '2023-08-31', 9999, 1),
(2, 'Order2', '2023-08-31', 19999, 1),
(3, 'Order3', '2023-08-31', 500, 2),
(5, 'NewOrder1', '2023-09-01', 15000, 4),
(6, 'NewOrder2', '2023-09-01', 5000, 4),
(7, 'NewOrder3', '2023-09-01', 50000, 5),
(8, 'NewOrder4', '2023-09-01', 100, 5);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `customers`
--
ALTER TABLE `customers`
  ADD PRIMARY KEY (`id_customer`);

--
-- Индексы таблицы `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`id_order`),
  ADD KEY `FK_orders_customers` (`id_customer`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `customers`
--
ALTER TABLE `customers`
  MODIFY `id_customer` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT для таблицы `orders`
--
ALTER TABLE `orders`
  MODIFY `id_order` int NOT NULL AUTO_INCREMENT;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `FK_orders_customers` FOREIGN KEY (`id_customer`) REFERENCES `customers` (`id_customer`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
