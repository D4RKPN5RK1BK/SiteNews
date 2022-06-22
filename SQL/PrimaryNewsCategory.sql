use goreftinsky;
alter table news_category add PRIMARY KEY (news_category_id);
alter table news_category MODIFY news_category_id integer NOT NULL AUTO_INCREMENT PRIMARY KEY;
alter table news ADD CONSTRAINT FK_news_newsCategories FOREIGN KEY (name_category) references news_category (news_category_id);