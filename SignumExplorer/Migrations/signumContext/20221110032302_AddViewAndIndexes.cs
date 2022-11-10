using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignumExplorer.Migrations
{
    public partial class AddViewAndIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            #region Indexes
            //Add Indexes
            migrationBuilder.Sql(@"CREATE OR REPLACE INDEX asset_height_idx ON asset(height);");
            migrationBuilder.Sql(@"CREATE OR REPLACE INDEX transaction_height_timestamp_idx ON `transaction`(height, timestamp);");
            migrationBuilder.Sql(@"CREATE OR REPLACE INDEX transaction_height_recip_sender_idx ON `transaction`(height, `type`, subtype, recipient_id, sender_id);");
            migrationBuilder.Sql(@"CREATE OR REPLACE INDEX transaction_subtype_idx ON `transaction`(subtype);");

            #endregion

            #region Views

            //Need this FIRST since other views depend on it

            migrationBuilder.Sql(@"
                CREATE OR REPLACE
                ALGORITHM = UNDEFINED VIEW `reward_recip_name_desc` AS
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


                ");

            //Need this second since other views depend on it.
            migrationBuilder.Sql(@"
CREATE OR REPLACE
ALGORITHM = UNDEFINED VIEW `latest_account_reward_recip` AS
select
    `a`.`db_id` AS `db_id`,
    `a`.`id` AS `id`,
    `a`.`creation_height` AS `creation_height`,
    `a`.`public_key` AS `public_key`,
    `a`.`key_height` AS `key_height`,
    `ab`.`balance` AS `balance`,
    `ab`.`unconfirmed_balance` AS `unconfirmed_balance`,
    `ab`.`forged_balance` AS `forged_balance`,
    `a`.`name` AS `name`,
    `a`.`description` AS `description`,
    `a`.`height` AS `height`,
    `a`.`latest` AS `latest`,
    `rrnd`.`recip_id` AS `recip_id`,
    `rrnd`.`from_height` AS `from_height`,
    `rrnd`.`recip_name` AS `recip_name`,
    `rrnd`.`recip_descrip` AS `recip_descrip`
from `account` `a`
		left join `reward_recip_name_desc` `rrnd` on
    	(`a`.`id` = `rrnd`.`account_id`)
    	left join `account_balance` `ab` on
    	(`a`.`id` = `ab`.`id`)
where
   `a`.`latest` = 1
    AND `ab`.`latest`=1;
    

                    ");

            migrationBuilder.Sql(@"CREATE OR REPLACE
ALGORITHM = UNDEFINED VIEW `latest_account_balance` AS
select
    `a`.`db_id` AS `db_id`,
    `a`.`id` AS `id`,
    `a`.`creation_height` AS `creation_height`,
    `a`.`public_key` AS `public_key`,
    `a`.`key_height` AS `key_height`,
    `ab`.`balance` AS `balance`,
    `ab`.`unconfirmed_balance` AS `unconfirmed_balance`,
    `ab`.`forged_balance` AS `forged_balance`,
    `a`.`name` AS `name`,
    `a`.`description` AS `description`,
    `a`.`height` AS `height`,
    `a`.`latest` AS `latest`
from
    (`account` `a`
left join `account_balance` `ab` on
    (`a`.`id` = `ab`.`id`))
where
    `a`.`latest` = 1
    and `ab`.`latest` = 1;");

            migrationBuilder.Sql(@"

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


                ");

            migrationBuilder.Sql(@"
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
    

                    ");

            migrationBuilder.Sql(@"
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
    

                    ");

            migrationBuilder.Sql(@"
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
    

                    ");




            migrationBuilder.Sql(@"
                CREATE OR REPLACE
                ALGORITHM = UNDEFINED VIEW `latest_ask_order` AS
                select
                    `ao`.`db_id` AS `db_id`,
                    `ao`.`id` AS `id`,
                    `ao`.`account_id` AS `account_id`,
                    `ao`.`asset_id` AS `asset_id`,
                    `ao`.`price` AS `price`,
                    `ao`.`quantity` AS `quantity`,
                    `ao`.`creation_height` AS `creation_height`,
                    `ao`.`height` AS `height`,
                    `ao`.`latest` AS `latest`,
                    `a`.`decimals` AS `decimals`,
                    `a`.`quantity` AS `asset_quantity`,
                    `a`.`name` AS `asset_name`
                from
                    (`ask_order` `ao`
                left join `asset` `a` on
                    (`ao`.`asset_id` = `a`.`id`))
                where
                    `ao`.`latest` = 1;
    

                    ");

            migrationBuilder.Sql(@"
                CREATE OR REPLACE
                ALGORITHM = UNDEFINED VIEW `latest_bid_order` AS
                select
                    `bo`.`db_id` AS `db_id`,
                    `bo`.`id` AS `id`,
                    `bo`.`account_id` AS `account_id`,
                    `bo`.`asset_id` AS `asset_id`,
                    `bo`.`price` AS `price`,
                    `bo`.`quantity` AS `quantity`,
                    `bo`.`creation_height` AS `creation_height`,
                    `bo`.`height` AS `height`,
                    `bo`.`latest` AS `latest`,
                    `a`.`decimals` AS `decimals`,
                    `a`.`quantity` AS `asset_quantity`,
                    `a`.`name` AS `asset_name`
                from
                    (`bid_order` `bo`
                left join `asset` `a` on
                    (`bo`.`asset_id` = `a`.`id`))
                where
                    `bo`.`latest` = 1; 
                ");




            migrationBuilder.Sql(@"
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
                        ");

            migrationBuilder.Sql(@"CREATE OR REPLACE
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
                ");

            migrationBuilder.Sql(@"

CREATE OR REPLACE
ALGORITHM = UNDEFINED VIEW `multi_out_transaction_attach` AS
select
    `t`.`db_id` AS `db_id`,
    `t`.`id` AS `id`,
    `t`.`sender_id` AS `sender_id`,
    `t`.`attachment_bytes` AS `attachment_bytes`,
    `t`.`type` AS `type`,
    `t`.`subtype` AS `subtype`,
    `t`.`amount` AS `amount`,
    `t`.`fee` AS `fee`,
    `t`.`timestamp` AS `timestamp`,
    `a`.`name` AS `sender_name`
from
    (`transaction` `t`
left join `account` `a` on
    (`t`.`sender_id` = `a`.`id`))
where
    `t`.`type` = 0
    and `t`.`subtype` <> 0
    and `a`.`latest` = 1
");

            migrationBuilder.Sql(@"CREATE OR REPLACE
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
        `signum`.`block` `b`) `sl`");



            #endregion

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            ////Drop Indexes
            migrationBuilder.Sql(@"  DROP INDEX asset_height_idx ON asset; ");
            migrationBuilder.Sql(@"  DROP INDEX transaction_height_timestamp_idx ON `transaction`; ");
            migrationBuilder.Sql(@"  DROP INDEX transaction_height_recip_sender_idx ON `transaction`; ");
            migrationBuilder.Sql(@"  DROP INDEX transaction_subtype_idx ON `transaction`; ");
            migrationBuilder.Sql(@" DROP VIEW account_asset_asset_details; ");
            migrationBuilder.Sql(@" DROP VIEW asset_transfer_asset_detail; ");
            migrationBuilder.Sql(@" DROP VIEW block_reward_recip_name; ");
            migrationBuilder.Sql(@" DROP VIEW latest_account_reward_recip; ");
            migrationBuilder.Sql(@" DROP VIEW latest_ask_order; ");
            migrationBuilder.Sql(@" DROP VIEW latest_bid_order; ");
            migrationBuilder.Sql(@" DROP VIEW reward_recip_name_desc; ");
            migrationBuilder.Sql(@" DROP VIEW trade_asset_detail; ");
            migrationBuilder.Sql(@" DROP VIEW block_pool_won; ");
            migrationBuilder.Sql(@" DROP VIEW ats_view; ");
            migrationBuilder.Sql(@" DROP VIEW latest_account_balance");


        }
    }
}

