export class OrderItem {
    Id: number | undefined;
    productId: number | undefined;
    productNumber: number | undefined;
    productName: string | undefined;
    productPicture: string | undefined;
    productPrice: number | undefined;
    productDescription: string | undefined;
    quantity: number | undefined;
    unitPrice: number | undefined;
}

export class Order {
    orderId: number | undefined;
    orderNumber: string | undefined;
    orderDate: Date = new Date();
    orderTotal: number | undefined;
    /*orderStatus: string | undefined;*/
    items: OrderItem[] = [];

    get subtotal(): number | undefined{

        const result = this.items.reduce(
            (tot, val?) => {
                return tot + ((val?.unitPrice??0)  * (val?.quantity ??0));
            }, 0);
        return result;
    }
}