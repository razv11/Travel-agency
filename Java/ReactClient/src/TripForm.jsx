import './TripForm.css'
import {useState} from "react";

export default function TripForm({addFunction}) {

    const [id, setId] = useState('');
    let [landmark, setLandmark] = useState('');
    let [transportCompanyName, setCompany] = useState('');
    const [departureTime, setDepartureTime] = useState('');
    const [price, setPrice] = useState('');
    const [availableSeats, setAvailableSeats] = useState('');

    function handleSubmit(event) {
        if(landmark === "") {
            alert("Landmark missing");
            return;
        }

        if(transportCompanyName === "") {
            alert("Transport company name missing");
            event.preventDefault();
            return;
        }

        if(departureTime === "") {
            alert("Departure time missing");
            event.preventDefault();
            return;
        }

        if(price === "") {
            alert("Price missing");
            event.preventDefault();
            return;
        }

        if(availableSeats === "") {
            alert("Available seats missing");
            event.preventDefault();
            return;
        }

        let trip = {
            id: id,
            landmark: landmark,
            transportCompanyName: transportCompanyName,
            departureTime: departureTime,
            price: price,
            availableSeats: availableSeats
        };

        addFunction(trip);
        event.preventDefault();

        setLandmark("");
        setCompany("");
        setDepartureTime("");
        setPrice("");
        setAvailableSeats("");
    }

    return (
        <form className="tripForm" onSubmit = {handleSubmit}>
            <div className="form-item">
                Landmark
                <input type="text" value={landmark} onChange={e => setLandmark(e.target.value)} />
            </div>
            <br/>
            <div className="form-item">
                Company name
                <input type="text" value={transportCompanyName} onChange={e => setCompany(e.target.value)} />
            </div>
            <br/>
            <div className="form-item">
                Departure date
                <input type="datetime-local" value={departureTime} onChange={e => setDepartureTime(e.target.value)}/>
            </div>
            <br/>
            <div className="form-item">
                Price
                <input type="number" step="0.01" value={price} onChange={e => setPrice(e.target.value)}/>
            </div>
            <br/>
            <div className="form-item">
                Available seats
                <input type="number" value={availableSeats} onChange={e => setAvailableSeats(e.target.value)}/>
            </div>
            <br/>
            <input type="submit" value="Add Trip" className="add-trip-button"/>
        </form>
    );
}