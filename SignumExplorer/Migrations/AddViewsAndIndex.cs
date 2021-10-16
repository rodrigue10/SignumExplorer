﻿

using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using SignumExplorer.Context;


#nullable disable

namespace SignumExplorer.Migrations
{

    [DbContext(typeof(signumContext))]
    [Migration("AddViewsAndIndex")]
    public partial class AddViewsAndIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            #region Indexes
            //Add Indexes
            migrationBuilder.Sql(@"  CREATE OR REPLACE INDEX asset_height ON asset(height); ");

            migrationBuilder.Sql(@"  CREATE OR REPLACE INDEX transaction_height_timestamp ON `transaction`(height, timestamp); ");

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



            #endregion

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            ////Drop Indexes
            migrationBuilder.Sql(@"  DROP INDEX asset_height ON asset; ");
            migrationBuilder.Sql(@"  DROP INDEX transaction_height_timestamp ON `transaction`; ");
            migrationBuilder.Sql(@" DROP VIEW account_asset_asset_details; ");
            migrationBuilder.Sql(@" DROP VIEW asset_transfer_asset_detail; ");
            migrationBuilder.Sql(@" DROP VIEW block_reward_recip_name; ");
            migrationBuilder.Sql(@" DROP VIEW latest_account_reward_recip; ");
            migrationBuilder.Sql(@" DROP VIEW latest_ask_order; ");
            migrationBuilder.Sql(@" DROP VIEW latest_bid_order; ");
            migrationBuilder.Sql(@" DROP VIEW reward_recip_name_desc; ");
            migrationBuilder.Sql(@" DROP VIEW trade_asset_detail; ");


        }
    }
}
