export class OrderItem {
    id: number | undefined;
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
    orderDate: Date = new Date();
    Items: Array<OrderItem> = new Array<OrderItem>();

    get subtotal(): number | undefined{

        const result = this.Items.reduce(
            (tot, val?) => {
                return tot + ((val?.unitPrice ?? 0) * (val?.quantity ?? 0));
                
            }, 0);
        return result;
    }
}