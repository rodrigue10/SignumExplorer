CREATE OR REPLACE
ALGORITHM = UNDEFINED VIEW `latest_bid_order` AS
select
    `bo`.`db_id` AS `db_id`,
    `bo`.`id` AS `id`,
    `bo`.`account_id` AS `account_id`,
    `bo`.`asset_id` AS `asset_id`,
    `bo`.`price` AS `price`,
    `bo`.`quantity` AS `quantity`,
    `bo`.`creation_height` AS `creation_height`,
    `bo`.`height` AS `height`,
    `bo`.`latest` AS `latest`,
    `a`.`decimals` AS `decimals`,
    `a`.`quantity` AS `asset_quantity`,
    `a`.`name` AS `asset_name`
from
    (`bid_order` `bo`
left join `asset` `a` on
    (`bo`.`asset_id` = `a`.`id`))
where
    `bo`.`latest` = 1;




