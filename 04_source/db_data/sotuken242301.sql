-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- ホスト: 127.0.0.1
-- 生成日時: 2026-01-19 12:27:15
-- サーバのバージョン： 10.4.32-MariaDB
-- PHP のバージョン: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- データベース: `sotuken242301`
--

-- --------------------------------------------------------

--
-- テーブルの構造 `bosr1`
--

CREATE TABLE `bosr1` (
  `ruoid` int(5) NOT NULL,
  `stationid` int(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- テーブルの構造 `bosr2`
--

CREATE TABLE `bosr2` (
  `ruoid` int(5) NOT NULL,
  `stationid` int(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- テーブルの構造 `com`
--

CREATE TABLE `com` (
  `busid` int(3) NOT NULL,
  `busname` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- テーブルの構造 `faredef`
--

CREATE TABLE `faredef` (
  `farepass` int(5) NOT NULL,
  `faread` int(2) NOT NULL,
  `period` int(3) NOT NULL,
  `medium` int(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- テーブルの構造 `farepass`
--

CREATE TABLE `farepass` (
  `busid` int(3) NOT NULL,
  `farepass` int(5) NOT NULL,
  `period` int(3) NOT NULL,
  `km` int(100) NOT NULL,
  `fare` int(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- テーブルの構造 `fareusu`
--

CREATE TABLE `fareusu` (
  `busid` int(3) NOT NULL,
  `medium` int(2) NOT NULL,
  `faread` int(2) NOT NULL,
  `minkm` int(100) NOT NULL,
  `maxkm` int(100) NOT NULL,
  `fare` int(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- テーブルの構造 `iccard`
--

CREATE TABLE `iccard` (
  `ICno` int(5) NOT NULL,
  `name` varchar(30) NOT NULL,
  `seinen` date NOT NULL,
  `bal` int(5) NOT NULL,
  `depo` varchar(30) NOT NULL,
  `stday` date NOT NULL,
  `endday` date NOT NULL,
  `depass` varchar(30) NOT NULL,
  `arpass` varchar(30) NOT NULL,
  `gepass` tinyint(1) NOT NULL,
  `teimon` int(5) NOT NULL,
  `new` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- テーブルのデータのダンプ `iccard`
--

INSERT INTO `iccard` (`ICno`, `name`, `seinen`, `bal`, `depo`, `stday`, `endday`, `depass`, `arpass`, `gepass`, `teimon`, `new`) VALUES
(1, 'a', '2026-01-19', 0, '', '0000-00-00', '0000-00-00', '', '', 0, 0, 0),
(2, 'b', '2026-01-19', 0, '', '0000-00-00', '0000-00-00', '', '', 0, 0, 0),
(3, 'b', '2026-01-19', 0, '', '0000-00-00', '0000-00-00', '', '', 0, 0, 0),
(4, '', '0000-00-00', 1000, '', '0000-00-00', '0000-00-00', '', '', 0, 0, 0),
(5, 'c', '2026-01-19', 0, '', '0000-00-00', '0000-00-00', '', '', 0, 0, 0),
(6, 'e', '2026-01-19', 1000, '', '0000-00-00', '0000-00-00', '', '', 0, 0, 0),
(7, 'f', '2026-01-19', 1000, '', '0000-00-00', '0000-00-00', '', '', 0, 0, 0),
(8, 'g', '2026-01-19', 1000, '', '0000-00-00', '0000-00-00', '', '', 0, 0, 0),
(9, 'b', '2026-01-19', 1000, '', '0000-00-00', '0000-00-00', '', '', 0, 0, 0),
(10, 'a', '2026-01-19', 1000, '', '0000-00-00', '0000-00-00', '', '', 0, 0, 0),
(11, 'a', '2026-01-19', 1000, '', '0000-00-00', '0000-00-00', '', '', 0, 0, 0),
(12, 'a', '2026-01-19', 0, '', '0000-00-00', '0000-00-00', '', '', 0, 0, 0),
(13, 'a', '2026-01-19', 0, '', '0000-00-00', '0000-00-00', '', '', 0, 0, 0),
(14, 'c', '2026-01-19', 0, '', '0000-00-00', '0000-00-00', '', '', 0, 0, 0),
(15, 'a', '2026-01-19', 0, '', '0000-00-00', '0000-00-00', '', '', 0, 0, 0),
(16, 'a', '2026-01-19', 1000, '', '0000-00-00', '0000-00-00', '', '', 0, 0, 0),
(17, 'a', '2026-01-19', 1000, '', '0000-00-00', '0000-00-00', '', '', 0, 0, 0),
(18, 'a', '2026-01-19', 1000, '', '0000-00-00', '0000-00-00', '', '', 0, 0, 0),
(19, 'a', '2026-01-19', 1000, '', '0000-00-00', '0000-00-00', '', '', 0, 0, 0),
(20, 'a', '2026-01-19', 1000, '', '0000-00-00', '0000-00-00', '', '', 0, 0, 0),
(21, 'a', '2026-01-01', 1000, '', '0000-00-00', '0000-00-00', '', '', 0, 0, 0),
(22, 'c', '2026-01-19', 1000, '', '0000-00-00', '0000-00-00', '', '', 0, 0, 0),
(23, 'd', '2026-01-19', 10000, '', '0000-00-00', '0000-00-00', '', '', 0, 0, 0),
(24, 's', '2026-01-19', 1000, '', '0000-00-00', '0000-00-00', '', '', 0, 0, 0);

-- --------------------------------------------------------

--
-- テーブルの構造 `resume`
--

CREATE TABLE `resume` (
  `ICno` int(5) NOT NULL,
  `reday` date NOT NULL,
  `bos` varchar(30) NOT NULL,
  `gos` varchar(30) NOT NULL,
  `fare` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- テーブルの構造 `ruote`
--

CREATE TABLE `ruote` (
  `busid` int(3) NOT NULL,
  `ruoid` int(5) NOT NULL,
  `ruoneme` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- ダンプしたテーブルのインデックス
--

--
-- テーブルのインデックス `bosr1`
--
ALTER TABLE `bosr1`
  ADD PRIMARY KEY (`ruoid`);

--
-- テーブルのインデックス `bosr2`
--
ALTER TABLE `bosr2`
  ADD PRIMARY KEY (`ruoid`);

--
-- テーブルのインデックス `com`
--
ALTER TABLE `com`
  ADD PRIMARY KEY (`busid`);

--
-- テーブルのインデックス `faredef`
--
ALTER TABLE `faredef`
  ADD PRIMARY KEY (`farepass`,`faread`,`period`,`medium`);

--
-- テーブルのインデックス `farepass`
--
ALTER TABLE `farepass`
  ADD PRIMARY KEY (`busid`,`farepass`,`period`);

--
-- テーブルのインデックス `fareusu`
--
ALTER TABLE `fareusu`
  ADD PRIMARY KEY (`busid`,`medium`,`faread`);

--
-- テーブルのインデックス `iccard`
--
ALTER TABLE `iccard`
  ADD PRIMARY KEY (`ICno`);

--
-- テーブルのインデックス `resume`
--
ALTER TABLE `resume`
  ADD PRIMARY KEY (`ICno`);

--
-- テーブルのインデックス `ruote`
--
ALTER TABLE `ruote`
  ADD PRIMARY KEY (`busid`,`ruoid`);

--
-- ダンプしたテーブルの AUTO_INCREMENT
--

--
-- テーブルの AUTO_INCREMENT `iccard`
--
ALTER TABLE `iccard`
  MODIFY `ICno` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- テーブルの AUTO_INCREMENT `resume`
--
ALTER TABLE `resume`
  MODIFY `ICno` int(5) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
