CREATE OR REPLACE
ALGORITHM = UNDEFINED VIEW `latest_account_reward_recip` AS
select
    `a`.`db_id` AS `db_id`,
    `a`.`id` AS `id`,
    `a`.`creation_height` AS `creation_height`,
    `a`.`public_key` AS `public_key`,
    `a`.`key_height` AS `key_height`,
    `a`.`balance` AS `balance`,
    `a`.`unconfirmed_balance` AS `unconfirmed_balance`,
    `a`.`forged_balance` AS `forged_balance`,
    `a`.`name` AS `name`,
    `a`.`description` AS `description`,
    `a`.`height` AS `height`,
    `a`.`latest` AS `latest`,
    `rrnd`.`recip_id` AS `recip_id`,
    `rrnd`.`from_height` AS `from_height`,
    `rrnd`.`recip_name` AS `recip_name`,
    `rrnd`.`recip_descrip` AS `recip_descrip`
from
    (`account` `a`
left join `reward_recip_name_desc` `rrnd` on
    (`a`.`id` = `rrnd`.`account_id`))
where
    `a`.`latest` = 1;