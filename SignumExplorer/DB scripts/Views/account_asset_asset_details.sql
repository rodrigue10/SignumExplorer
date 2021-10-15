CREATE OR REPLACE
ALGORITHM = UNDEFINED VIEW `asset_transfer_asset_detail` AS
select
    `t`.`db_id` AS `db_id`,
    `t`.`id` AS `id`,
    `t`.`asset_id` AS `asset_id`,
    `t`.`sender_id` AS `sender_id`,
    `t`.`recipient_id` AS `recipient_id`,
    `t`.`quantity` AS `quantity`,
    `t`.`timestamp` AS `timestamp`,
    `t`.`height` AS `height`,
    `a`.`quantity` AS `asset_quantity`,
    `a`.`decimals` AS `decimals`,
    `a`.`name` AS `asset_name`
from
    (`asset_transfer` `t`
left join `asset` `a` on
    (`t`.`asset_id` = `a`.`id`));