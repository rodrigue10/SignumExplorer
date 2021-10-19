CREATE OR REPLACE
ALGORITHM = UNDEFINED VIEW `multi_out_transaction_attach` AS
select
    `t`.`id` AS `id`,
    `t`.`sender_id` AS `sender_id`,
    `t`.`attachment_bytes` AS `attachment_bytes`,
    `t`.`type` AS `type`,
    `t`.`subtype` AS `subtype`,
    `t`.`amount` AS `amount`,
    `t`.`fee` AS `fee`,
    `t`.`timestamp` AS `timestamp`
from
    `transaction` `t`
where
    `t`.`type` = 0
    and `t`.`subtype` <> 0
