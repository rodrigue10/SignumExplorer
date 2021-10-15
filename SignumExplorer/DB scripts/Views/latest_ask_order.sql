CREATE OR REPLACE
ALGORITHM = UNDEFINED VIEW `latest_ask_order` AS
select
    `ao`.`db_id` AS `db_id`,
    `ao`.`id` AS `id`,
    `ao`.`account_id` AS `account_id`,
    `ao`.`asset_id` AS `asset_id`,
    `ao`.`price` AS `price`,
    `ao`.`quantity` AS `quantity`,
    `ao`.`creation_height` AS `creation_height`,
    `ao`.`height` AS `height`,
    `ao`.`latest` AS `latest`,
    `a`.`decimals` AS `decimals`,
    `a`.`quantity` AS `asset_quantity`,
    `a`.`name` AS `asset_name`
from
    (`ask_order` `ao`
left join `asset` `a` on
    (`ao`.`asset_id` = `a`.`id`))
where
    `ao`.`latest` = 1;