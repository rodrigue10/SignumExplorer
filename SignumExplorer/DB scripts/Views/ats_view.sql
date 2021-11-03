 CREATE OR REPLACE
                ALGORITHM = UNDEFINED VIEW `ats_view` AS
                select
                    `a`.`db_id` AS `db_id`,
                    `a`.`id` AS `id`,
                    `a`.`creator_id` AS `creator_id`,
                    `a`.`name` AS `name`,
                    `a`.`description` AS `description`,
                    `a`.`version` AS `version`,
                    `a`.`csize` AS `csize`,
                    `a`.`dsize` AS `dsize`,
                    `a`.`c_user_stack_bytes` AS `c_user_stack_bytes`,
                    `a`.`c_call_stack_bytes` AS `c_call_stack_bytes`,
                    `a`.`creation_height` AS `creation_height`,
                    `a`.`height` AS `height`,
                    `a`.`latest` AS `latest`,
                    `a`.`ap_code_hash_id` AS `ap_code_hash_id`,
                    `a2`.`ap_code` AS `ap_code`
                from
                    (`signum`.`at` `a`
                left join (
                    select
                        distinct `a3`.`ap_code_hash_id` AS `ap_code_hash_id`,
                        `a3`.`ap_code` AS `ap_code`
                    from
                        `signum`.`at` `a3`
                    where
                        `a3`.`ap_code` is not null) `a2` on
                    (`a`.`ap_code_hash_id` = `a2`.`ap_code_hash_id`))
                order by
                    `a`.`height` desc;