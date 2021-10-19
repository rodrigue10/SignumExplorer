CREATE OR REPLACE
                ALGORITHM = UNDEFINED VIEW `transaction_account_names` AS
                select
                    `t`.`db_id` AS `db_id`,
                    `t`.`id` AS `id`,
                    `t`.`deadline` AS `deadline`,
                    `t`.`sender_public_key` AS `sender_public_key`,
                    `t`.`recipient_id` AS `recipient_id`,
                    `t`.`amount` AS `amount`,
                    `t`.`fee` AS `fee`,
                    `t`.`height` AS `height`,
                    `t`.`block_id` AS `block_id`,
                    `t`.`signature` AS `signature`,
                    `t`.`timestamp` AS `timestamp`,
                    `t`.`type` AS `type`,
                    `t`.`subtype` AS `subtype`,
                    `t`.`sender_id` AS `sender_id`,
                    `t`.`block_timestamp` AS `block_timestamp`,
                    `t`.`full_hash` AS `full_hash`,
                    `t`.`referenced_transaction_fullhash` AS `referenced_transaction_fullhash`,
                    `t`.`attachment_bytes` AS `attachment_bytes`,
                    `t`.`version` AS `version`,
                    `t`.`has_message` AS `has_message`,
                    `t`.`has_encrypted_message` AS `has_encrypted_message`,
                    `t`.`has_public_key_announcement` AS `has_public_key_announcement`,
                    `t`.`has_encrypttoself_message` AS `has_encrypttoself_message`,
                    `t`.`ec_block_height` AS `ec_block_height`,
                    `t`.`ec_block_id` AS `ec_block_id`,
                    `a`.`name` AS `sender_name`,
                    `a2`.`name` AS `recipient_name`
                from
                    ((`transaction` `t`
                left join `account` `a` on
                    (`t`.`sender_id` = `a`.`id`))
                left join `account` `a2` on
                    (`t`.`recipient_id` = `a2`.`id`))
                where
                    `a`.`latest` = 1
                    and `a2`.`latest` = 1
                order by
                    `t`.`height` desc;