
CREATE TABLE [BOUQUET](
    [ID] int NOT NULL IDENTITY,
    [NAME] VARCHAR(255) NOT NULL,
    [PRICE] FLOAT not NULL,
    [DESCRIPTION] TEXT NOT NULL,
    [IMG] VARCHAR(255) NOT NULL
);

INSERT INTO [BOUQUET] (NAME, PRICE, DESCRIPTION, IMG) VALUES
('15 Pink Jewel Roses', 8500, 'A stunning bouquet of 15 pink jewel roses. This beautiful arrangement is perfect for expressing love and admiration.', 'img1.webp'),
('10 Long Stemmed White Roses', 5999, 'Elegant bouquet of 10 long stemmed white roses. These pristine flowers symbolize purity and innocence, making them an ideal gift for various occasions.', 'img2.webp'),
('20 Pink Pearl Roses', 12500, 'A luxurious arrangement of 20 pink pearl roses. These exquisite roses are sure to make a statement and bring joy to the recipient.', 'img3.webp'),
('30 Purple Tulips', 10000, 'Vibrant bouquet featuring 30 purple tulips. Tulips are known for their beauty and grace, making them a perfect choice for any celebration or special moment.', 'img4.webp'),
('A Bountiful Harvest', 17000, 'A bountiful arrangement of colorful flowers. This stunning bouquet is a true celebration of nature’s beauty and abundance, perfect for any occasion.', 'img5.webp'),
('Beyond Sapphire Flowers', 9999, 'Exquisite bouquet featuring beyond sapphire flowers. These unique flowers symbolize loyalty and trust, making them a meaningful gift for someone special.', 'img6.webp'),
('Birthday Blast', 6500, 'A blast of colors perfect for birthdays. This vibrant bouquet is sure to brighten up anyone’s special day and bring a smile to their face.', 'img7.webp'),
('Bonanza', 6500, 'A delightful bonanza of flowers. This beautiful arrangement is a true feast for the eyes, featuring a variety of colorful blooms.', 'img8.webp'),
('Bright Centerpiece', 7999, 'Bright and beautiful centerpiece for any occasion. This stunning arrangement is sure to be the focal point of any room and is perfect for adding a pop of color to your space.', 'img9.webp'),
('Bunch of 10 Mixed Roses', 2800, 'A bunch of 10 mixed roses for a charming gift. This lovely bouquet features a variety of colors, making it a perfect choice for expressing love and appreciation.', 'img10.webp');
