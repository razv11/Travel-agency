import {TRAVEL_AGENCY_BASE_URL} from "./consts.js";

function status(response) {
    if(response.status >= 200 && response.status < 300) {
        return Promise.resolve(response);
    }
    return Promise.reject(response);
}

function json(response) {
    return response.json();
}

export function GetTrips() {
    let headers = new Headers();
    headers.append('Accept', 'application/json');
    //headers.append('Content-Type', 'application/json;charset=UTF-8');

    let myInit = { method: 'GET', headers: headers, mode: 'cors' };
    let request = new Request(TRAVEL_AGENCY_BASE_URL, myInit);

    return fetch(request)
        .then(status)
        .then(json)
        .then(data => {
            return data;
        }).catch(error => {
            return Promise.reject(error);
        });
}

export function AddTrip(trip){
    let myHeaders = new Headers();
    myHeaders.append('Accept', 'application/json');
    myHeaders.append('Content-Type', 'application/json;charset=UTF-8');

    let myInit = { method: 'POST', headers: myHeaders, mode: 'cors', body: JSON.stringify(trip) };

    console.log(trip);

    return fetch(TRAVEL_AGENCY_BASE_URL, myInit)
        .then(status)
        .then(response => {
            return response.text();
        }).catch(error => {
            return Promise.reject(error);
        });
}

export function DeleteTrip(id) {
    let myHeaders = new Headers();
    myHeaders.append('Accept', 'application/json');

    let myInit = { method: 'DELETE', headers: myHeaders, mode: 'cors' };

    const tripDeleteUrl = TRAVEL_AGENCY_BASE_URL + '/' + id;
    return fetch(tripDeleteUrl, myInit)
        .then(status)
        .then(response => {
            return response.text();
        }).catch(error => {
            return Promise.reject(error);
        });
}

export function UpdateTrip(trip) {
    let myHeaders = new Headers();
    myHeaders.append('Accept', 'application/json');
    myHeaders.append('Content-Type', 'application/json;charset=UTF-8');

    let myInit = { method: 'PUT', headers: myHeaders, mode: 'cors', body: JSON.stringify(trip) };

    const tripUpdateUrl = TRAVEL_AGENCY_BASE_URL + '/' + trip.id;
    return fetch(tripUpdateUrl, myInit)
        .then(status)
        .then(json)
        .then(data => {
            return data;
        }).catch(error => {
            return Promise.reject(error);
        });
}