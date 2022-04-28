CREATE OR REPLACE
ALGORITHM = UNDEFINED VIEW `block_pool_won` AS
select
    `sl`.`height` AS `height`,
    `sl`.`generator_id` AS `generator_id`,
    ifnull(`sl`.`pool`, `sl`.`generator_id`) AS `pool_id`,
    if(`sl`.`pool` is null,
    1,
    0) AS `solo`
from
    (
    select
        `b`.`height` AS `height`,
        `b`.`generator_id` AS `generator_id`,
        cast((select `t`.`recipient_id` from `signum`.`transaction` `t` where `t`.`type` = 20 and `t`.`subtype` = 0 and `t`.`sender_id` = `b`.`generator_id` and `t`.`height` + 4 <= `b`.`height` order by `t`.`height` desc limit 1) as signed) AS `pool`
    from
        `signum`.`block` `b`) `sl`