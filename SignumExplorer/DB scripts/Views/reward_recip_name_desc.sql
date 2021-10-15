select
    `rra`.`db_id` AS `db_id`,
    `rra`.`account_id` AS `account_id`,
    `rra`.`prev_recip_id` AS `prev_recip_id`,
    `rra`.`recip_id` AS `recip_id`,
    `rra`.`from_height` AS `from_height`,
    `rra`.`height` AS `height`, 
    `rra`.`latest` AS `latest`,
    `a`.`name` AS `recip_name`,
    `a`.`description` AS `recip_descrip`
from
    (`reward_recip_assign` `rra`
left join `account` `a` on
    (`rra`.`recip_id` = `a`.`id`))
where
    `rra`.`latest` = 1
    and `a`.`latest` = 1;
