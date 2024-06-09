import './Modal-Window.css'
import {useState} from "react";

export default function ModalWindow({trip, updateFunction, closeModal}) {
    const [id, setId] = useState(trip.id);
    const [landmark, setLandmark] = useState(trip.landmark);
    const [transportCompanyName, setCompany] = useState(trip.transportCompanyName);
    const [departureTime, setDepartureTime] = useState(trip.departureTime);
    const [price, setPrice] = useState(trip.price);
    const [availableSeats, setAvailableSeats] = useState(trip.availableSeats);

    function handleUpdate(event) {
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

        updateFunction(trip);
        event.preventDefault();

        setLandmark("");
        setCompany("");
        setDepartureTime("");
        setPrice("");
        setAvailableSeats("");
        closeModal();
    }

    return (
        <div className="modal-container" onClick = { (e) => { if(e.target.className === 'modal-container') closeModal(); } } >
            <div className="modal" onSubmit={handleUpdate}>
                <form>
                    <div className="form-group">
                        <label htmlFor="landmark">Landmark</label>
                        <input type="text" name="landmark" value={landmark} onChange={e => setLandmark(e.target.value)}/>
                    </div>

                    <div className="form-group">
                        <label htmlFor="transportCompanyName">Company name</label>
                        <input type="text" name="transportCompanyName" value={transportCompanyName} onChange={e => setCompany(e.target.value)}/>
                    </div>

                    <div className="form-group">
                        <label htmlFor="departureTime">Departure time</label>
                        <input type="datetime-local" name="departureTime" value={departureTime} onChange={e => setDepartureTime(e.target.value)}/>
                    </div>

                    <div className="form-group">
                        <label htmlFor="price">Price</label>
                        <input type="number" step="0.01" name="price" value={price} onChange={e => setPrice(e.target.value)}/>
                    </div>

                    <div className="form-group">
                        <label htmlFor="availableSeats">Available Seats</label>
                        <input type="number" name="availableSeats" value={availableSeats} onChange={e => setAvailableSeats(e.target.value)}/>
                    </div>

                    <input type="submit" value='Update' className="btn" />
                </form>
            </div>
        </div>
    );
}