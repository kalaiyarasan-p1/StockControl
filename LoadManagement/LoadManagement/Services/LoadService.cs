using LoadManagement.LoadModels;

namespace LoadManagement.Services
{
    internal class LoadService
    {
        /// <summary>
        ///  Method to check load can be fulfilled by warehouse
        /// </summary>
        /// <param name="load"></param>
        /// <param name="warehouse"></param>
        /// <returns></returns>
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

        public static IEnumerable<Load> GetCustomerLoadsSortedByDeliveryTime(Customer customer)
        {
            var loadslist = GetLoads().Where(c => c.Customer.Id == customer.Id);
            return loadslist.OrderBy(l => l.DeliveryTime);  
        }

        /// <summary>
        /// Method to return fulfilled customer loads sorted by delivery time
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static int GetNumberOfLoadsThatCanBeFulfilled(Customer customer)
        {
            List<Load> fulfilledLoads = new();
            var loads = LoadService.GetCustomerLoadsSortedByDeliveryTime(customer);
            foreach (var load in loads)
            {
                var warehouses = LoadService.GetWarehouses();
                foreach (var warehouse in warehouses)
                {
                    bool isLoadFulfilled = LoadService.CanFulfillLoadFromWarehouse(load, warehouse);
                    if (isLoadFulfilled)
                    {
                        fulfilledLoads.Add(load);
                    }
                }
            }

            return fulfilledLoads.Count;
        }

        private static Stock? GetStockByWarehouseAndFreightItem(Warehouse warehouse, FreightItem freightItem)
        {
            return GetStocks().FirstOrDefault(s => s.Warehouse.WarehouseId == warehouse.WarehouseId && s.FreightItem.FreightItemId == freightItem.FreightItemId);
        }

        private static List<Stock> GetStocks() => new();
        public static List<Load> GetLoads() => new();
        public static List<Warehouse> GetWarehouses() => new();
    }
}
