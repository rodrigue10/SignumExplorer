
using Microsoft.EntityFrameworkCore;
using SignumExplorer.Context;
using SignumExplorer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignumExplorer.Signum;
using Pomelo.EntityFrameworkCore.MySql;
using System.Reflection;

namespace SignumExplorer.Data;

public interface ISignumDataService
{

    #region Counting Functions
    public Task<AccountCounts> AccountCountItems(long account);

    public Task<BlockCounts> BlockCountItems(long account);
    public Task<BlockCounts> BlockCountItems(Block block);

    public Task<NodeCounts> NodeCountItems();

    public Task<int> AssetDecimals(ulong assetId);

    public Task<AssetCounts> AssetCounts(long assetId);

    public Task<AtCounts> AtCounts(long atId);
    public Task<AliasCounts> AliasCounts(long aliasId);

    #region Individual Counts

    public Task<int> BlockCount();

    public Task<int> TransactionCount();

    public Task<int> AssetCount();

    public Task<int> AliasCount();
    public Task<int> ATCount();
    public Task<int> AccountCount();

    #endregion

    #endregion

    #region Assets
    public Task<IEnumerable<ITrade>> GetTrades(long assetId);


    public Task<IEnumerable<IAssetTransfer>> GetAssetTransfers(long assetId);

    public Task<IEnumerable<ITrade>> GetTradesDB(long assetId);


    public Task<IEnumerable<IAssetTransfer>> GetAssetTransfersDB(long assetId);
    public  Task<IEnumerable<IAsset>> GetQueryableAssets();

    public Task<IEnumerable<IAsset>> GetFilteredSortedPagedAssets(string searchString , string? sortLabel, int page = 0, int pageSize = 50, int sortOrder = 0);
    public Task<List<IAsset>> GetAssets();
    public Task<IAsset> GetAsset(string assetID);

    public Task<List<IAccountAsset>> GetAssetHolders(long assetId);
    public Task<IEnumerable<IAskOrder>> GetAskOrdersDB(long assetId);
    public  Task<IEnumerable<IBidOrder>> GetBidOrdersDB(long assetId);

    public Task<IEnumerable<IBidOrder>> GetBidOrders(long assetId);

    public Task<IEnumerable<IAskOrder>> GetAskOrders(long assetId);

    #endregion

    #region Blocks
    public  Task<IEnumerable<IBlock>> GetFilteredSortedPagedBlocksView(string searchString, string? sortLabel, int page = 0, int pageSize = 50, int sortOrder = 0);
    public Task<IEnumerable<IBlock>> GetFilteredSortedPagedBlocks(string searchString, string? sortLabel, int page = 0, int pageSize = 50, int sortOrder = 0);
    public Task<List<IBlock>> GetBlocks();
    public Task<List<IBlock>?> GetBlocksAsync();

    public Task<List<Block>> GetBlocksBlock();
    public Task<List<IBlock>> GetBlocks(int latest);

    public Task<IEnumerable<IBlock>> GetLatestBlocks(int latest);

    public Task<IBlock> GetBlockHeight(int height);
    public Task<IBlock> GetBlock(long blockid);

    #endregion

    #region Transactions

    public Task<IEnumerable<ITransaction>> GetFilteredSortedPagedTransactions(string searchString, string? sortLabel, int page = 0, int pageSize = 50, int sortOrder = 0);

    public Task<HashSet<ITransaction>> GetBlockTransactions(long blockid);

    public Task<IEnumerable<ITransaction>> GetLatestTransactions(int taken);


    #endregion

    #region Ats

    public Task<IEnumerable<ITransaction>> GetAtTransactions(long atId);
    public Task<IAt> GetSingleAt(long atId);
    public Task<IEnumerable<IAt>> GetAts(int taken);
    public Task<IEnumerable<IAt>> GetFilteredSortedPagedAts(string searchString, string? sortLabel, int page = 0, int pageSize = 50, int sortOrder = 0);

    public Task<IAtState> GetLatestAtState(long atId);
    public Task<IEnumerable<IAtState>> GetAllAtState(long atId);
    public Task<IEnumerable<IAtState>> GetFilteredSortedPagedAtStates_All(string searchString, string? sortLabel, int page = 0, int pageSize = 50, int sortOrder = 0);


    #endregion




    #region Reward Recipient
    public Task<IRewardRecipAssign?> GetAccountRewardRecipient(long accountId);
    public Task<IEnumerable<IRewardRecipAssign>?> GetPoolAccountMembers(long accountId);


    #endregion


    #region Account

    public Task<IEnumerable<IAt>?> GetAccountCreatedAts(long accountId);
    public Task<IEnumerable<ITransaction>> AccountMultiOutTrans(long accountId);
    public Task<IEnumerable<ITransaction>> GetFilteredSortedPagedAccountTransactions(long account, string searchString, string? sortLabel, int page = 0, int pageSize = 50, int sortOrder = 0);

    public Task<IEnumerable<ITransaction>> GetFilteredSortedPagedAccountMultiOut(long account, string searchString, string? sortLabel, int page = 0, int pageSize = 50, int sortOrder = 0);
    public Task<IEnumerable<IAccount>> GetFilteredSortedPagedAccounts(string searchString, string? sortLabel, int page = 0, int pageSize = 50, int sortOrder = 0);

    public Task<List<IBlock>> GetAccountBlocks(long accountId);
    public Task<List<IAccountAsset>> GetAccountAssets(long accountId);
    public Task<IAccount> GetAccount(long accountId);

    public Task<List<ITransaction>> GetAccountTransactions(long accountid);
    public Task<List<ITransaction>> GetAccountTransactions(long accountid, int take);

    public Task<List<Account>> GetAccounts(int taken);

    public Task<IEnumerable<IAskOrder>> GetAccountAskOrdersDB(long accountId);
    public Task<IEnumerable<IBidOrder>> GetAccountBidOrdersDB(long accountId);
    public Task<IEnumerable<IBidOrder>> GetAccountBidOrders(long accountId);
    public  Task<IEnumerable<IAskOrder>> GetAccountAskOrders(long accountId);
    public Task<List<ITrade>> GetAccountTrades(long accountId);

    public Task<List<IAssetTransfer>> GetAccountAssetTransfers(long accountId);
    #endregion



    public Task<List<ITransaction>> GetTransactions(int taken);

    public Task<ITransaction> GetTransaction(long txId);


    public Task<UnconfirmedTransaction> GetUnconfirmedTransaction(long txId);

    public Task<List<UnconfirmedTransaction>> GetUnconfirmedTransactions(int taken);

    #region Aliases

    public Task<IEnumerable<IAlias>> GetFilteredSortedPagedAliases(string searchString, string? sortLabel, int page = 0, int pageSize = 50, int sortOrder = 0);
    public Task<List<IAlias>> GetAliases(int take);

    public  Task<IAlias?> GetAlias(long aliasId);

    public Task<List<IAlias>> GetAliases();

    public Task<IEnumerable<IAliasOffer>> GetAliasOffers(long aliasId);

    public Task<List<IAlias>> GetAccountAliases(long accountId);


    #endregion


    #region Test/Prototype Methods



    #endregion

}


public class SignumDataService : ISignumDataService
{

    private readonly IDbContextFactory<signumContext> _contextFactory;

    public SignumDataService(IDbContextFactory<signumContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }


    #region Count Functions

        #region Aggregated Counts
        public async Task<NodeCounts> NodeCountItems()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
            var count = new NodeCounts
            {
                Ats = await context.Ats.CountAsync(),
                AtStates = await context.AtStates.CountAsync(),
                AtsLatest = await context.Ats.Where(m => m.Latest.Value).CountAsync(),
                AtStatesLatest = await context.AtStates.Where(m => m.Latest.Value).CountAsync(),


                    Blocks = await context.Blocks.CountAsync(),
                    Transactions = await context.Transactions.CountAsync(),
                    Assets = await context.Assets.CountAsync(),
                    Aliases = await context.Aliases.Where(m =>m.Latest.Value).CountAsync(),
                    Accounts = await context.Accounts.Where(m => m.Latest.Value).CountAsync(),
                };


                return count;
            }

        }

 
    public async Task<AccountCounts> AccountCountItems(long account)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var count = new AccountCounts
                {
                    AllTrans = await context.Transactions.CountAsync(m => (m.RecipientId == account || m.SenderId == account)),
                    MultiTrans = await context.Transactions.CountAsync(m => (m.RecipientId == account || m.SenderId == account)
                                && m.Type == (sbyte)TransactionTypes.Primary.Payment
                                     && m.Subtype != (sbyte)TransactionTypes.Payment.OrdinaryPayment),
                    SingleTrans = await context.Transactions.CountAsync(m => (m.RecipientId == account || m.SenderId == account)
                                    && m.Type == (sbyte)TransactionTypes.Primary.Payment
                                    && m.Subtype == (sbyte)TransactionTypes.Payment.OrdinaryPayment),
                    ForgedBlocks = await context.Blocks.CountAsync(m => (m.GeneratorId == account)),
                    AssetTransfers = await context.AssetTransfers.CountAsync(m => m.RecipientId == account || m.SenderId == account),
                    AssetHoldings = await context.AccountAssets.CountAsync(m => m.AccountId == account && m.Latest.Value),
                    AssetTrades = await context.Trades.CountAsync(m => m.BuyerId == account || m.SellerId == account),
                    AssetAsks = await context.AskOrders.CountAsync(m => m.AccountId == account && m.Latest.Value),
                    AssetBids = await context.BidOrders.CountAsync(m => m.AccountId == account && m.Latest.Value),
                    Aliases = await context.Aliases.CountAsync(m => m.AccountId == account && m.Latest.Value),
                    PoolMembers = await context.RewardRecipAssigns.CountAsync(m => m.RecipId == account && m.AccountId != account && m.Latest.Value),
                    Ats = await context.Ats.CountAsync(m => m.CreatorId == account),
                };


                return count;
            }
        }

        public async Task<BlockCounts> BlockCountItems(long block)
        {

            using (var context = _contextFactory.CreateDbContext())
            {

                var blockcount = new BlockCounts
                {
                    Transactions = await context.Transactions.CountAsync(m => m.BlockId == block)
                };

                return blockcount;

            }

        }

    public async Task<AtCounts> AtCounts(long atId)
    {

        using (var context = _contextFactory.CreateDbContext())
        {

            AtCounts atCounts = new()
            {
                AtStates = await context.AtStates.CountAsync(m => m.AtId == atId),
                AtTransactions = await context.Transactions.CountAsync(m => m.SenderId == atId || m.RecipientId == atId)


            };

            return atCounts;

        }

    }
    public async Task<BlockCounts> BlockCountItems(Block block)
        {

            using (var context = _contextFactory.CreateDbContext())
            {

                var blockcount = new BlockCounts
                {
                    Transactions = await context.Entry(block).Collection(m => m.Transactions).Query().CountAsync()
                };

                return blockcount;

            }

        }

    public async Task<int> AssetDecimals(ulong assetId)
    {
        using (var context = _contextFactory.CreateDbContext())
        {
            var item = await context.Assets.Where(m => m.Id == (long)assetId).FirstAsync();

         

            return item.Decimals;

            

        }
    }

    public async Task<AssetCounts> AssetCounts(long assetId)
    {


        using (var context = _contextFactory.CreateDbContext())
        {
            var count = new AssetCounts
            {
                Trades = await context.Trades.Where(m => m.AssetId == assetId).CountAsync(),
                Transfers = await context.AssetTransfers.Where(m => m.AssetId == (long)assetId).CountAsync(),
                Holders = await context.AccountAssets.Where(m => m.AssetId == (long)assetId && m.Latest.Value).CountAsync(),
                OpenBidsOrders = await context.AskOrders.Where(m => m.AssetId == (long)assetId && m.Latest.Value).CountAsync(),
                OpenAsksOrders = await context.BidOrders.Where(m => m.AssetId == (long)assetId && m.Latest.Value).CountAsync(),

            };

            return count;

        }
    }

    public async Task<AliasCounts> AliasCounts(long aliasId)
    {
        using (var context = _contextFactory.CreateDbContext())
        {
            var count = new AliasCounts

            {
                AliasOffers = await context.AliasOffers.CountAsync(m => m.Id == aliasId && m.Latest.Value)

            };

            return count;

        }
    }


    #endregion

    #region Individual Counts
    public async Task<int> BlockCount()
    {
        using (var context = _contextFactory.CreateDbContext())
        {
            

            //counting blocks takes a long time
            //assume the Block height is the same as block count
           var block =  await context.Blocks.OrderByDescending(m => m.Height).Take(1).FirstAsync();

            //add 1 to include Block 0
            return block.Height + 1;
            //return await context.Blocks.Select(m => m.Height).CountAsync();




        }
    }
    public async Task<int> TransactionCount()
    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.Transactions.CountAsync();
        }
    }
    public async Task<int> AssetCount()
    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.Assets.CountAsync();
        }
    }
    public async Task<int> AliasCount()
    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.Aliases.Where(m => m.Latest.Value).CountAsync();
        }
    }
    public async Task<int> ATCount()
    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.Ats.CountAsync();
        }
    }
    public async Task<int> AccountCount()
    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.Accounts.Where(m => m.Latest.Value).CountAsync();
        }
    }

    #endregion


    #endregion

    #region Assets

    public async Task<IEnumerable<IAsset>> GetQueryableAssets()

    {
        using (var context = _contextFactory.CreateDbContext())
        {

            return await context.Assets.ToListAsync();
            

        }

    }
    public async Task<IEnumerable<IAsset>> GetFilteredSortedPagedAssets(string searchString, string? sortLabel, int page = 0, int pageSize = 50, int sortOrder = 0)

    {
        using (var context = _contextFactory.CreateDbContext())
        {
            IQueryable<Asset>? query;

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                query = context.Assets.Where(element =>
                    element.Name.ToLower().Contains(searchString.ToLower())
                       || element.Description.ToLower().Contains(searchString.ToLower()))
                        .AsQueryable<Asset>();
            }
            else
            {
                query = context.Assets.AsQueryable<Asset>();
            }

            if (!string.IsNullOrWhiteSpace(sortLabel) && sortOrder != 0)
            {
                if (sortOrder == 2)
                {

                    query = query.OrderBy(sortLabel, true);

                }
                else if (sortOrder == 1)
                {
                    query = query.OrderBy(sortLabel, false);
                }
                
                
            }
            else
            {
                query = query.OrderByDescending(m => m.Height);
            }
            return await query.Skip(page * pageSize).Take(pageSize).ToListAsync();


        }

    }

    public async Task<List<IAsset>> GetAssets()

    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return  await context.Assets.OrderByDescending(o => o.Height).ToListAsync<IAsset>();

        }

    }

    public async Task<IAsset> GetAsset(string assetID)

    {
        using (var context = _contextFactory.CreateDbContext())
            {
            return await context.Assets.Where(o => ((ulong)o.Id).ToString() == assetID).FirstAsync();

        }
        

    }


    public async Task<IEnumerable<ITrade>> GetTradesDB(long assetId)

    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.Trades.Where(o => o.AssetId == assetId).OrderByDescending(o => o.Height).ToListAsync<ITrade>();

        }

    }

    public async Task<IEnumerable<ITrade>> GetTrades(long assetId)

    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.TradeAssetDetails.Where(o => o.AssetId == assetId).OrderByDescending(o => o.Height).ToListAsync<ITrade>();

        }

    }

    public async Task<IEnumerable<IBidOrder>> GetBidOrdersDB(long assetId)

    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.BidOrders.Where(o => o.AssetId == assetId && o.Latest.Value).OrderByDescending(o => o.Price).ToListAsync<IBidOrder>();

        }

    }
    public async Task<IEnumerable<IAskOrder>> GetAskOrdersDB(long assetId)

    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.AskOrders.Where(o => o.AssetId == assetId && o.Latest.Value).OrderBy(o => o.Price).ToListAsync<IAskOrder>();

        }

    }

    #region View Dependency
            public async Task<IEnumerable<IBidOrder>> GetBidOrders(long assetId)

            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    return await context.LatestBidOrders.Where(o => o.AssetId == assetId ).OrderByDescending(o => o.Price).ToListAsync<IBidOrder>();

                }

            }
            public async Task<IEnumerable<IAskOrder>> GetAskOrders(long assetId)

            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    return await context.LatestAskOrders.Where(o => o.AssetId == assetId ).OrderBy(o => o.Price).ToListAsync<IAskOrder>();

                }

            }
    #endregion

    public async Task<IEnumerable<IAssetTransfer>> GetAssetTransfersDB(long assetId)

    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.AssetTransfers.Where(o => o.AssetId == assetId).OrderByDescending(o => o.Height).ToListAsync<IAssetTransfer>();

        }

    }

    public async Task<IEnumerable<IAssetTransfer>> GetAssetTransfers(long assetId)

    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.AssetTransferAssetDetails.Where(o => o.AssetId == assetId).OrderByDescending(o => o.Height).ToListAsync<IAssetTransfer>();

        }

    }

    public async Task<List<IAccountAsset>> GetAssetHolders(long assetId)

    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.AccountAssets.Where(o => o.AssetId == assetId && o.Latest.Value).OrderByDescending(o => o.Height).ToListAsync<IAccountAsset>();

        }

    }

    #endregion

    #region Blocks
    public async Task<IEnumerable<IBlock>> GetFilteredSortedPagedBlocksView(string searchString, string? sortLabel, int page = 0, int pageSize = 50, int sortOrder = 0)

    {
        using (var context = _contextFactory.CreateDbContext())
        {
            IQueryable<IBlock>? query;

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                query = context.BlockRewardRecipDescs.AsQueryable<IBlock>().Where(element =>
                    element.Height.ToString().ToLower().Contains(searchString.ToLower())
                    || element.GeneratorId.ToString().ToLower().Contains(searchString.ToLower())
                       || element.Id.ToString().ToLower().Contains(searchString.ToLower())
                       )
                        .AsQueryable();
            }
            else
            {
                query = context.BlockRewardRecipDescs.AsQueryable<IBlock>();
            }

            if (!string.IsNullOrWhiteSpace(sortLabel) && sortOrder != 0)
            {
                if (sortOrder == 2)
                {

                    query = query.OrderBy(sortLabel, true);

                }
                else if (sortOrder == 1)
                {
                    query = query.OrderBy(sortLabel, false);
                }


            }
            else
            {
                query = query.OrderByDescending(m => m.Height);
            }
            return await query.Skip(page * pageSize).Take(pageSize).ToListAsync();


        }

    }

    public async Task<IEnumerable<IBlock>> GetFilteredSortedPagedBlocks(string searchString, string? sortLabel, int page = 0, int pageSize = 50, int sortOrder = 0)

    {
        using (var context = _contextFactory.CreateDbContext())
        {
            IQueryable<IBlock>? query;

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                query = context.Blocks.AsQueryable<IBlock>().Where(element =>
                    element.Height.ToString().ToLower().Contains(searchString.ToLower())
                    || element.GeneratorId.ToString().ToLower().Contains(searchString.ToLower())
                       || element.Id.ToString().ToLower().Contains(searchString.ToLower())
                       )
                        .AsQueryable();
            }
            else
            {
                query = context.Blocks.AsQueryable<IBlock>();
            }

            if (!string.IsNullOrWhiteSpace(sortLabel) && sortOrder != 0)
            {
                if (sortOrder == 2)
                {

                    query = query.OrderBy(sortLabel, true);

                }
                else if (sortOrder == 1)
                {
                    query = query.OrderBy(sortLabel, false);
                }


            }
            else
            {
                query = query.OrderByDescending(m => m.Height);
            }
            return await query.Skip(page * pageSize).Take(pageSize).Include(m => m.Transactions).ToListAsync();


        }

    }


    public async Task<List<IBlock>?> GetBlocksAsync()

    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.Blocks.OrderByDescending(o => o.Height).Include(m => m.Transactions).Take(2000).ToListAsync<IBlock>();

        }

    }

    public async Task<List<IBlock>> GetBlocks()

    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.Blocks.OrderByDescending(o => o.Height).Include(m => m.Transactions).Take(2000).ToListAsync<IBlock>();

        }

    }

    public async Task<List<Block>> GetBlocksBlock()

    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.Blocks.OrderByDescending(o => o.Height).Include(m => m.Transactions).Take(2000).ToListAsync<Block>();

        }

    }

    public async Task<List<IBlock>> GetBlocks(int latest)

    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.Blocks.OrderByDescending(o => o.Height).Include(m=>m.Transactions).Take(latest).ToListAsync<IBlock>();

        }

    }
    public async Task<IEnumerable<IBlock>> GetLatestBlocks(int latest)

    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.BlockRewardRecipDescs.OrderByDescending(m =>m.Height).Take(latest).ToListAsync<IBlock>();

        }

    }





    public async Task<IBlock> GetBlockHeight(int height)

    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.Blocks.Where(o => o.Height == height).Include(m=>m.Transactions).FirstAsync<IBlock>();

        }

    }

    public async Task<IBlock> GetBlock(long blockid)

    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.Blocks.Where(o => o.Id == blockid).Include(m=>m.Transactions).FirstAsync<IBlock>();

        }

    }
    #endregion

    #region Reward Recipient
    public async Task<IRewardRecipAssign?> GetAccountRewardRecipient(long accountId)

    {
        using (var context = _contextFactory.CreateDbContext())
        {

            var item = await context.RewardRecipAssigns.Where(m => m.AccountId == accountId && m.Latest.Value).ToListAsync();

            if (item.Count != 0)
            {
                return item.FirstOrDefault<IRewardRecipAssign>();
            }
            else { return null; }

        }

    }

    public async Task<IEnumerable<IRewardRecipAssign>?> GetPoolAccountMembers(long accountId)

    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.RewardRecipAssigns.Where(m => m.RecipId == accountId && m.AccountId != accountId && m.Latest.Value).ToListAsync<IRewardRecipAssign>();
        }

    }

    #endregion

    #region Accounts

    public async Task<IEnumerable<IAt>?> GetAccountCreatedAts(long accountId)
    {
        using (var context = _contextFactory.CreateDbContext())
        {

            return await context.Ats.Where(m => m.CreatorId == accountId).ToListAsync();

        }

    }
    public async Task<IEnumerable<ITransaction>> AccountMultiOutTrans(long accountId)
    {
        using (var context = _contextFactory.CreateDbContext())
        {

            return await context.Transactions.Where(m => (m.RecipientId == accountId || m.SenderId == accountId)
                                    && m.Type == 0
                                     && m.Subtype != 0).ToListAsync<ITransaction>();

        }
    }

    public async Task<IEnumerable<ITransaction>> GetFilteredSortedPagedAccountTransactions(long account, string searchString, string? sortLabel, int page = 0, int pageSize = 50, int sortOrder = 0)

    {
        using (var context = _contextFactory.CreateDbContext())
        {
            IQueryable<Transaction>? query;

            query = context.Transactions.Where(m => m.SenderId == account || m.RecipientId == account);

            query = query.Where(m => !(m.Subtype != (int)TransactionTypes.Payment.OrdinaryPayment && m.Type == (int)TransactionTypes.Primary.Payment) );

            if (!string.IsNullOrWhiteSpace(searchString))
            {
               // query = query.Where(element => element. (
                    //element.CreationHeight.ToString().ToLower().Contains(searchString.ToLower())
                    //|| element.AccountId.ToString().ToLower().Contains(searchString.ToLower())
                    //||
                  //  element.Name.ToString().ToLower().Contains(searchString.ToLower())
                       //|| element.Description.ToString().ToLower().Contains(searchString.ToLower())
                       //))
                       // .AsQueryable();
            }
            else
            {
               // query = query.Where(element => element.Latest.Value).AsQueryable<ITransaction>();
            }

            if (!string.IsNullOrWhiteSpace(sortLabel) && sortOrder != 0)
            {
                if (sortOrder == 2)
                {

                    query = query.OrderBy(sortLabel, true);

                }
                else if (sortOrder == 1)
                {
                    query = query.OrderBy(sortLabel, false);
                }


            }
            else
            {
                query = query.OrderByDescending(m => m.Height);
            }
            return await query.Skip(page * pageSize).Take(pageSize).ToListAsync();


        }

    }

    public async Task<IEnumerable<ITransaction>> GetFilteredSortedPagedAccountMultiOut(long account, string searchString, string? sortLabel, int page = 0, int pageSize = 50, int sortOrder = 0)

    {
        using (var context = _contextFactory.CreateDbContext())
        {
            IQueryable<Transaction>? query;

            query = context.Transactions.Where(m => m.SenderId == account || m.RecipientId == account);

            query = query.Where(m => m.Subtype != (int)TransactionTypes.Payment.OrdinaryPayment && m.Type == (int)TransactionTypes.Primary.Payment);

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                // query = query.Where(element => element. (
                //element.CreationHeight.ToString().ToLower().Contains(searchString.ToLower())
                //|| element.AccountId.ToString().ToLower().Contains(searchString.ToLower())
                //||
                //  element.Name.ToString().ToLower().Contains(searchString.ToLower())
                //|| element.Description.ToString().ToLower().Contains(searchString.ToLower())
                //))
                // .AsQueryable();
            }
            else
            {
                // query = query.Where(element => element.Latest.Value).AsQueryable<ITransaction>();
            }

            if (!string.IsNullOrWhiteSpace(sortLabel) && sortOrder != 0)
            {
                if (sortOrder == 2)
                {

                    query = query.OrderBy(sortLabel, true);

                }
                else if (sortOrder == 1)
                {
                    query = query.OrderBy(sortLabel, false);
                }


            }
            else
            {
                query = query.OrderByDescending(m => m.Height);
            }
            return await query.Skip(page * pageSize).Take(pageSize).ToListAsync();


        }

    }


    public async Task<IEnumerable<IAccount>> GetFilteredSortedPagedAccounts(string searchString, string? sortLabel, int page = 0, int pageSize = 50, int sortOrder = 0)

    {

        List<IAccount> accounts = new List<IAccount>();
        //Try to convert to account id
        var accountSuccess = ulong.TryParse(searchString, out ulong accountString);


        //Search for name or Exact ID

        using (var context = _contextFactory.CreateDbContext())
        {
            IQueryable<IAccount>? query;



            if (!string.IsNullOrWhiteSpace(searchString))
            {
                //Search for exact account ID and add to the result list
                if (accountSuccess)
                {
                    var result = await context.Accounts.Where(m => m.Latest.Value && m.Id == (long)accountString).FirstOrDefaultAsync<IAccount>();
                    if(result != null) accounts.Add(result);

                }

                //search on other text fields base on text even if numbers
                
                
                    query = context.Accounts.AsQueryable<IAccount>().Where(element => element.Latest.Value 
                            && (element.Name.Contains(searchString)
                            || element.Description.Contains(searchString)))
                            .AsQueryable();
                

            }
            //Grab everything available
            else
            {
                query = context.Accounts.Where(element => element.Latest.Value).AsQueryable<IAccount>();
            }

            if (!string.IsNullOrWhiteSpace(sortLabel) && sortOrder != 0)
            {
                if (sortOrder == 2)
                {

                    query = query.OrderBy(sortLabel, true);

                }
                else if (sortOrder == 1)
                {
                    query = query.OrderBy(sortLabel, false);
                }


            }
            else
            {
                query = query.OrderByDescending(m => m.CreationHeight);
            }


            var secondResult = await query.Skip(page * pageSize).Take(pageSize).ToListAsync();


            return accounts.Concat(secondResult);

        }

    }
    public async Task<List<Account>> GetAccounts(int taken)

    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.Accounts.Where(o => o.PublicKey != null && o.Latest.Value).Take(taken).ToListAsync();

        }

    }

    public async Task<IAccount> GetAccount(long accountId)

    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.Accounts.Where(o => o.Id == accountId && o.Latest.Value).FirstAsync<IAccount>();

        }

    }


    public async Task<IEnumerable<IBidOrder>> GetAccountBidOrdersDB(long accountId)

    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.BidOrders.Where(o => o.AccountId == accountId && o.Latest.Value).OrderByDescending(o => o.CreationHeight).ToListAsync<IBidOrder>();

        }

    }
    public async Task<IEnumerable<IAskOrder>> GetAccountAskOrdersDB(long accountId)

    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.AskOrders.Where(o => o.AccountId == accountId && o.Latest.Value).OrderByDescending(o => o.CreationHeight).ToListAsync<IAskOrder>();

        }

    }

    #region View Dependency

            public async Task<IEnumerable<IBidOrder>> GetAccountBidOrders(long accountId)

            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    return await context.LatestBidOrders.Where(o => o.AccountId == accountId).OrderByDescending(o => o.CreationHeight).ToListAsync<IBidOrder>();

                }

            }
            public async Task<IEnumerable<IAskOrder>> GetAccountAskOrders(long accountId)

            {
                using (var context = _contextFactory.CreateDbContext())
                {
                    return await context.LatestAskOrders.Where(o => o.AccountId == accountId).OrderByDescending(o => o.CreationHeight).ToListAsync<IAskOrder>();

                }

            }
    #endregion



    public async Task<List<ITrade>> GetAccountTrades(long accountId)

    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.Trades.Where(o => o.SellerId == accountId || o.BuyerId == accountId).OrderByDescending(o => o.Timestamp).ToListAsync<ITrade>();

        }

    }

    public async Task<List<IBlock>> GetAccountBlocks(long accountId)

    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.Blocks.Where(o => o.GeneratorId == accountId).ToListAsync<IBlock>();

        }

    }
    public async Task<List<IAccountAsset>> GetAccountAssets(long accountId)

    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.AccountAssets.Where(o => o.AccountId == (long)accountId && o.Latest.Value).ToListAsync<IAccountAsset>();

        }

    }

    public async Task<List<IAssetTransfer>> GetAccountAssetTransfers(long accountId)

    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.AssetTransfers.Where(o => o.SenderId == accountId || o.RecipientId == accountId).ToListAsync<IAssetTransfer>();

        }

    }




    #endregion



    #region Transactions

    public async Task<IEnumerable<ITransaction>> GetFilteredSortedPagedTransactions(string searchString, string? sortLabel, int page = 0, int pageSize = 50, int sortOrder = 0)

    {
        using (var context = _contextFactory.CreateDbContext())
        {
            IQueryable<ITransaction>? query;

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                query = context.Transactions.AsQueryable<ITransaction>().Where(element =>
                    element.Height.ToString().ToLower().Contains(searchString.ToLower())
                    || element.RecipientId.ToString().ToLower().Contains(searchString.ToLower())
                    || element.SenderId.ToString().ToLower().Contains(searchString.ToLower())
                       || element.Id.ToString().ToLower().Contains(searchString.ToLower())
                       )
                        .AsQueryable();
            }
            else
            {
                query = context.Transactions.AsQueryable<ITransaction>();
            }

            if (!string.IsNullOrWhiteSpace(sortLabel) && sortOrder != 0)
            {
                if (sortOrder == 2)
                {

                    query = query.OrderBy(sortLabel, true);

                }
                else if (sortOrder == 1)
                {
                    query = query.OrderBy(sortLabel, false);
                }


            }
            else
            {
                query = query.OrderByDescending(m => m.Height);
            }
            return await query.Skip(page * pageSize).Take(pageSize).ToListAsync();


        }

    }

    public async Task<List<ITransaction>> GetTransactions(int taken)

    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.Transactions.OrderByDescending(o => o.Height).Take(taken).ToListAsync<ITransaction>();

        }

    }

    public async Task<IEnumerable<ITransaction>> GetLatestTransactions(int taken)

    {
        using (var context = _contextFactory.CreateDbContext())
        {
           return await context.Transactions.OrderByDescending(m => m.Height).Take(taken).ToListAsync<ITransaction>();

              

        }

    }

    public async Task<List<ITransaction>> GetAccountTransactions(long accountid)

    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.Transactions.OrderByDescending(o => o.Timestamp).Where(o => o.SenderId == accountid || o.RecipientId == accountid ).ToListAsync<ITransaction>();

        }

    }

    public async Task<List<ITransaction>> GetAccountTransactions(long accountid, int take)

    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.Transactions.OrderByDescending(o => o.Timestamp).Where(o => o.SenderId == accountid || o.RecipientId == accountid).Take(take).ToListAsync<ITransaction>();

        }

    }

    public Task<HashSet<ITransaction>> GetBlockTransactions(long blockid)

    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return Task.FromResult(context.Transactions.OrderByDescending(o => o.Timestamp).Where(o=>o.BlockId == blockid).ToHashSet<ITransaction>());

        }

    }





    public async Task<ITransaction> GetTransaction(long txId)

    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.Transactions.Where(o => o.Id == txId).FirstAsync<ITransaction>();

        }

    }
    #endregion

    #region Aliases

    public async Task<IEnumerable<IAlias>> GetFilteredSortedPagedAliases(string searchString, string? sortLabel, int page = 0, int pageSize = 50, int sortOrder = 0)

    {
        using (var context = _contextFactory.CreateDbContext())
        {
            IQueryable<IAlias>? query;

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                query = context.Aliases.AsQueryable<IAlias>().Where(element => element.Latest.Value && (

                    element.AliasNameLower.Contains(searchString.ToLower())
                   
                       ))
                        .AsQueryable();
            }
            else
            {
                query = context.Aliases.Where(element => element.Latest.Value).AsQueryable<IAlias>();
            }

            if (!string.IsNullOrWhiteSpace(sortLabel) && sortOrder != 0)
            {
                if (sortOrder == 2)
                {

                    query = query.OrderBy(sortLabel, true);

                }
                else if (sortOrder == 1)
                {
                    query = query.OrderBy(sortLabel, false);
                }


            }
            else
            {
                query = query.OrderByDescending(m => m.Height);
            }
            return await query.Skip(page * pageSize).Take(pageSize).ToListAsync();


        }

    }

    public async Task<IAlias?> GetAlias(long aliasId)
    {
        using (var context = _contextFactory.CreateDbContext())
        {

            return await context.Aliases.Where(o => o.Id == aliasId && o.Latest.Value).FirstAsync();
        }

    }

    public async Task<List<IAlias>> GetAliases(int take)
    {
        using (var context = _contextFactory.CreateDbContext())
        {

            return await context.Aliases.Where(o => o.Latest.Value).OrderByDescending(o=>o.Height).Take(take).ToListAsync<IAlias>();
        }

    }

    public async Task<List<IAlias>> GetAliases()
    {
        using (var context = _contextFactory.CreateDbContext())
        {

            return await context.Aliases.Where(o => o.Latest.Value).OrderByDescending(o => o.Height).ToListAsync<IAlias>();
        }

    }

    public async Task<IEnumerable<IAliasOffer>> GetAliasOffers(long aliasId)
    {
        using (var context = _contextFactory.CreateDbContext())
        {

            return await context.AliasOffers.Where(m => m.Id == aliasId).ToListAsync();
        }

    }

    public async Task<List<IAlias>> GetAccountAliases(long accountId)
    {
        using (var context = _contextFactory.CreateDbContext())
        {

            return await context.Aliases.Where(o => o.AccountId == accountId).OrderByDescending(o => o.AliasName).ToListAsync<IAlias>();
        }

    }


    #endregion

    #region Unconfirmed Transactions

    /// <summary>
    /// Gets Unconfirmed Transactions from DB
    /// </summary>
    /// <param name="taken"></param>
    /// <returns></returns>
    public async Task<List<UnconfirmedTransaction>> GetUnconfirmedTransactions(int taken)

    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.UnconfirmedTransactions.OrderByDescending(o => o.Timestamp).Take(taken).ToListAsync();
        }

    }

    public async Task<UnconfirmedTransaction> GetUnconfirmedTransaction(long txId)

    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.UnconfirmedTransactions.Where(o => o.Id == txId).FirstAsync();

        }

    }


    #endregion


    #region Ats

    #region View Dependency

    /// <summary>
    /// Used for showing the details of a Smart Contract.  Uses View as source to resolve missing ApCodeString data for Carbon Contracts.
    /// </summary>
    /// <param name="atId"></param>
    /// <returns></returns>
    public async Task<IAt> GetSingleAt(long atId)
    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.AtsViews.Where(m => m.Id == atId).FirstAsync();

        }
    }


    #endregion

    public async Task<IEnumerable<ITransaction>> GetAtTransactions(long atId)
    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.Transactions.Where(m => m.SenderId == atId || m.RecipientId == atId).OrderByDescending(m => m.Height).ToListAsync();

        }
    }



    /// <summary>
    /// Uses DB At Table, Carbon Contracts will be missing ApCode String Data.  
    /// </summary>
    /// <param name="taken"></param>
    /// <returns></returns>
    public async Task<IEnumerable<IAt>> GetAts(int taken)
    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.Ats.OrderByDescending(m => m.Height).Take(taken).ToListAsync();

        }
    }

    public async Task<IEnumerable<IAt>> GetFilteredSortedPagedAts(string searchString, string? sortLabel, int page = 0, int pageSize = 50, int sortOrder = 0)
    {
        using (var context = _contextFactory.CreateDbContext())
        {
            IQueryable<IAt>? query;

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                query = context.Ats.AsQueryable<IAt>().Where(m => m.Id.ToString().ToLower().Contains(searchString.ToLower())
                        || m.Name.ToLower().Contains(searchString.ToLower())
                
                       )
                        .AsQueryable();
            }
            else
            {
                query = context.Ats.AsQueryable<IAt>();
            }

            if (!string.IsNullOrWhiteSpace(sortLabel) && sortOrder != 0)
            {
                if (sortOrder == 2)
                {

                    query = query.OrderBy(sortLabel, true);

                }
                else if (sortOrder == 1)
                {
                    query = query.OrderBy(sortLabel, false);
                }


            }
            else
            {
                query = query.OrderByDescending(m => m.Height);
            }
            return await query.Skip(page * pageSize).Take(pageSize).ToListAsync();

        }
    }



    public async Task<IAtState> GetLatestAtState(long atId)
    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.AtStates.Where(m => m.AtId == atId && m.Latest.Value).FirstAsync();

        }
    }
    public async Task<IEnumerable<IAtState>> GetAllAtState(long atId)
    {
        using (var context = _contextFactory.CreateDbContext())
        {
            return await context.AtStates.Where(m => m.AtId == atId).OrderByDescending(m => m.Height).ToListAsync();

        }
    }

    public async Task<IEnumerable<IAtState>> GetFilteredSortedPagedAtStates_All(string searchString, string? sortLabel, int page = 0, int pageSize = 50, int sortOrder = 0)
    {
        using (var context = _contextFactory.CreateDbContext())
        {
            IQueryable<IAtState>? query;

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                query = context.AtStates.AsQueryable<IAtState>().Where(element =>
                    element.AtId.ToString().ToLower().Contains(searchString.ToLower())
                       )
                        .AsQueryable();
            }
            else
            {
                query = context.AtStates.AsQueryable<IAtState>();
            }

            if (!string.IsNullOrWhiteSpace(sortLabel) && sortOrder != 0)
            {
                if (sortOrder == 2)
                {

                    query = query.OrderBy(sortLabel, true);

                }
                else if (sortOrder == 1)
                {
                    query = query.OrderBy(sortLabel, false);
                }


            }
            else
            {
                query = query.OrderByDescending(m => m.Height);
            }
            return await query.Skip(page * pageSize).Take(pageSize).ToListAsync();
        }
    }
    #endregion

    #region Test/Prototype Methods



    #endregion


}
