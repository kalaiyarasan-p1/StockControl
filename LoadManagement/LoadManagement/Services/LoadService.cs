using LoadManagement.LoadModels;

namespace LoadManagement.Services
{
    internal class LoadService
    {
        public static bool CanFulfillLoadFromWarehouse(Load load, Warehouse warehouse)
        {
            foreach (LoadItem loadItem in load.LoadItems)
            {
                Stock? stock = GetStockByWarehouseAndFreightItem(warehouse, loadItem.FreightItem);
                if (stock == null || stock.StockQuantity < loadItem.Quantity)
                {
                    return false;
                }
            }

            return true;
        }

        private static Stock? GetStockByWarehouseAndFreightItem(Warehouse warehouse, FreightItem freightItem)
        {
            return GetStocks().FirstOrDefault(s => s.Warehouse.WarehouseId == warehouse.WarehouseId && s.FreightItem.FreightItemId == freightItem.FreightItemId);
        }

        private static List<Stock> GetStocks()
        {
            return new List<Stock>();
        }
    }
}
