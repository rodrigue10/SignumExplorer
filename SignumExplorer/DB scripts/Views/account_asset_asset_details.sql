CREATE OR REPLACE
ALGORITHM = UNDEFINED VIEW `account_asset_asset_details` AS
select
    `aa`.`db_id` AS `db_id`,
    `aa`.`account_id` AS `account_id`,
    `aa`.`asset_id` AS `asset_id`,
    `aa`.`quantity` AS `quantity`,
    `aa`.`unconfirmed_quantity` AS `unconfirmed_quantity`,
    `aa`.`height` AS `height`,
    `aa`.`latest` AS `latest`,
    `a`.`quantity` AS `asset_quantity`,
    `a`.`decimals` AS `decimals`,
    `a`.`name` AS `asset_name`
from
    (`account_asset` `aa`
left join `asset` `a` on
    (`aa`.`asset_id` = `a`.`id`))
where
    `aa`.`latest` = 1;