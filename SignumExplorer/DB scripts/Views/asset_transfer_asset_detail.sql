CREATE OR REPLACE
ALGORITHM = UNDEFINED VIEW `trade_asset_detail` AS
select
    `t`.`db_id` AS `db_id`,
    `t`.`asset_id` AS `asset_id`,
    `t`.`block_id` AS `block_id`,
    `t`.`ask_order_id` AS `ask_order_id`,
    `t`.`bid_order_id` AS `bid_order_id`,
    `t`.`ask_order_height` AS `ask_order_height`,
    `t`.`bid_order_height` AS `bid_order_height`,
    `t`.`seller_id` AS `seller_id`,
    `t`.`buyer_id` AS `buyer_id`,
    `t`.`quantity` AS `quantity`,
    `t`.`price` AS `price`,
    `t`.`timestamp` AS `timestamp`,
    `t`.`height` AS `height`,
    `a`.`quantity` AS `asset_quantity`,
    `a`.`decimals` AS `decimals`,
    `a`.`name` AS `asset_name`
from
    (`trade` `t`
left join `asset` `a` on
    (`t`.`asset_id` = `a`.`id`));