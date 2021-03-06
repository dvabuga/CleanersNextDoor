﻿import { post, get } from "./api.service";

const _CONTROLLER = 'customers'

export const customerService = {
    getCustomer,
    checkEmailAvailability,
    getPaymentMethods,
    addPaymentMethod,
    removePaymentMethod,
    setDefaultPaymentMethod,
    getAddresses,
    addAddress,
    removeAddress,
    setDefaultAddress,
    getCart,
    removeCartItem,
    cartTransaction,
    stripeClientSecret,
    stripePublicKey,
    createServiceRequest,
    getOrderHistory,
    getOrder,
    tryPayWithPaymentMethod
};
//Customer
function getCustomer() {
    return get(`${_CONTROLLER}/account`)
}
function checkEmailAvailability(email) {
    return get(`customers/CheckEmailAvailability/${email}`)
}

//Payment Methods
function getPaymentMethods() {
    return get(`${_CONTROLLER}/getPaymentMethods`)
}
function addPaymentMethod(data) {
    return post(`${_CONTROLLER}/AddPaymentMethod`, data)
}
function removePaymentMethod(data) {
    return post(`${_CONTROLLER}/removePaymentMethod`, data)
}
function setDefaultPaymentMethod(data) {
    return post(`${_CONTROLLER}/setDefaultPaymentMethod`, data)
}
//Addresses
function getAddresses() {
    return get(`${_CONTROLLER}/getAddresses`)
}
function addAddress(data) {
    return post(`${_CONTROLLER}/AddAddress`, data)
}
function removeAddress(data) {
    return post(`${_CONTROLLER}/removeAddress`, data)
}
function setDefaultAddress(data) {
    return post(`${_CONTROLLER}/setDefaultAddress`, data)
}
//Cart
function getCart(merchantId, allowCheckout) {
    let allow = allowCheckout !== undefined ? allowCheckout : false;
    return get(`${_CONTROLLER}/cart/${merchantId}/${allow}`)
}
function removeCartItem(data) {
    return post(`${_CONTROLLER}/removeCartItem`, data)
}
function cartTransaction(data) {
    return post(`${_CONTROLLER}/addtocart`, data)
}
function createServiceRequest(data) {
    return post(`${_CONTROLLER}/createServiceRequest`, data)
}

function tryPayWithPaymentMethod(data) {
    return post(`${_CONTROLLER}/tryPayWithPaymentMethod`, data)
}

function stripeClientSecret() {
    return post(`${_CONTROLLER}/stripeClientSecret`)
}

function stripePublicKey() {
    return post(`${_CONTROLLER}/stripePublicKey`)
}

//Orders
function getOrderHistory() {
    return get(`${_CONTROLLER}/orderHistory`)
}
function getOrder(orderId) {
    return get(`${_CONTROLLER}/getOrder/${orderId}`)
}

