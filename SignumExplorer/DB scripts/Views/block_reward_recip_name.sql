CREATE OR REPLACE
ALGORITHM = UNDEFINED VIEW `block_reward_recip_desc` AS
select
    `b`.`db_id` AS `db_id`,
    `b`.`id` AS `id`,
    `b`.`version` AS `version`,
    `b`.`timestamp` AS `timestamp`,
    `b`.`previous_block_id` AS `previous_block_id`,
    `b`.`total_amount` AS `total_amount`,
    `b`.`total_fee` AS `total_fee`,
    `b`.`payload_length` AS `payload_length`,
    `b`.`generator_public_key` AS `generator_public_key`,
    `b`.`previous_block_hash` AS `previous_block_hash`,
    `b`.`cumulative_difficulty` AS `cumulative_difficulty`,
    `b`.`base_target` AS `base_target`,
    `b`.`next_block_id` AS `next_block_id`,
    `b`.`height` AS `height`,
    `b`.`generation_signature` AS `generation_signature`,
    `b`.`block_signature` AS `block_signature`,
    `b`.`payload_hash` AS `payload_hash`,
    `b`.`generator_id` AS `generator_id`,
    `b`.`nonce` AS `nonce`,
    `b`.`ats` AS `ats`,
    `larr`.`name` AS `name`,
    `larr`.`recip_id` AS `recip_id`,
    `larr`.`recip_name` AS `recip_name`,
    (
    select
        count(`t`.`block_id`)
    from
        `transaction` `t`
    where
        `t`.`block_id` = `b`.`id`) AS `transaction_count`
from
    (`block` `b`
left join `latest_account_reward_recip` `larr` on
    (`b`.`generator_id` = `larr`.`id`))
order by
    `b`.`height` desc;