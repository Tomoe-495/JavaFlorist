
CREATE DATABASE JavaFlorist;

CREATE TABLE [CUSTOMER](
    [CUSTID] INT PRIMARY KEY IDENTITY,
    [FNAME] VARCHAR(255) NOT NULL,
    [LNAME] VARCHAR(255) NOT NULL,
    [DOB] DATE NOT NULL,
    [GENDER] CHAR NOT NULL,
    [PNO] VARCHAR(15) NOT NULL,
    [ADDRESS] TEXT NOT NULL
);

CREATE TABLE [BOUQUET](
    [BOUQUETID] int PRIMARY KEY IDENTITY,
    [NAME] VARCHAR(255) NOT NULL,
    [PRICE] FLOAT not NULL,
    [DESCRIPTION] TEXT NOT NULL,
    [IMG] VARCHAR(255) NOT NULL
);

INSERT INTO [BOUQUET] (NAME, PRICE, DESCRIPTION, IMG) VALUES
('15 Pink Jewel Roses', 8500, 'A stunning bouquet of 15 pink jewel roses. This beautiful arrangement is perfect for expressing love and admiration.', '../Resources/img1.webp'),
('10 Long Stemmed White Roses', 5999, 'Elegant bouquet of 10 long stemmed white roses. These pristine flowers symbolize purity and innocence, making them an ideal gift for various occasions.', '../Resources/img2.webp'),
('20 Pink Pearl Roses', 12500, 'A luxurious arrangement of 20 pink pearl roses. These exquisite roses are sure to make a statement and bring joy to the recipient.', '../Resources/img3.webp'),
('30 Purple Tulips', 10000, 'Vibrant bouquet featuring 30 purple tulips. Tulips are known for their beauty and grace, making them a perfect choice for any celebration or special moment.', '../Resources/img4.webp'),
('A Bountiful Harvest', 17000, 'A bountiful arrangement of colorful flowers. This stunning bouquet is a true celebration of nature’s beauty and abundance, perfect for any occasion.', '../Resources/img5.webp'),
('Beyond Sapphire Flowers', 9999, 'Exquisite bouquet featuring beyond sapphire flowers. These unique flowers symbolize loyalty and trust, making them a meaningful gift for someone special.', '../Resources/img6.webp'),
('Birthday Blast', 6500, 'A blast of colors perfect for birthdays. This vibrant bouquet is sure to brighten up anyone’s special day and bring a smile to their face.', '../Resources/img7.webp'),
('Bonanza', 6500, 'A delightful bonanza of flowers. This beautiful arrangement is a true feast for the eyes, featuring a variety of colorful blooms.', '../Resources/img8.webp'),
('Bright Centerpiece', 7999, 'Bright and beautiful centerpiece for any occasion. This stunning arrangement is sure to be the focal point of any room and is perfect for adding a pop of color to your space.', '../Resources/img9.webp'),
('Bunch of 10 Mixed Roses', 2800, 'A bunch of 10 mixed roses for a charming gift. This lovely bouquet features a variety of colors, making it a perfect choice for expressing love and appreciation.', '../Resources/img10.webp');


CREATE TABLE [OCCASION](
    [OCCASIONID] INT PRIMARY KEY IDENTITY,
    [MESSAGE] VARCHAR(255) NOT NULL
);

INSERT INTO [OCCASION] (MESSAGE) VALUES
('Congratulations on your special day!'),
('Wishing you all the best!'),
('Celebrate like a star!'),
('Cheers to you and your success!'),
('May this occasion be memorable!'),
('Here''s to many more happy moments!'),
('Enjoy every moment of this special occasion!'),
('You deserve all the happiness in the world!'),
('Sending you lots of love and joy!'),
('May this celebration be just the beginning of a wonderful journey!');

CREATE TABLE [CART](
    [CARTID] INT PRIMARY KEY IDENTITY,
    [CUSTID] INT NOT NULL FOREIGN KEY REFERENCES CUSTOMER(CUSTID),
    [BOUQUETID] INT NOT NULL FOREIGN KEY REFERENCES BOUQUET(BOUQUETID),
    [QUANTITY] INT NOT NULL DEFAULT 1
)

CREATE TABLE [ORDER](
    [ORDERID] INT PRIMARY KEY IDENTITY,
    [CUSTID] INT NOT NULL FOREIGN KEY REFERENCES CUSTOMER(CUSTID),
    [ORDERNAME] VARCHAR(255) NOT NULL,
    [ORDERADDRESS] TEXT NOT NULL,
    [ORDERPHONE] VARCHAR(15) NOT NULL,
    [ORDERDATE] DATE NOT NULL,
);
