package travelAgency.clientAMS;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import travelAgency.model.Trip;
import travelAgency.persistence.TripRepository;

import java.util.Optional;
import java.util.stream.StreamSupport;

@RestController
@RequestMapping("/travelagency/trips")
@CrossOrigin(origins = "http://localhost:5173")
public class TripController {
    @Autowired
    private TripRepository tripRepository;

    @RequestMapping(method = RequestMethod.GET)
    public Trip[] getAll() {
        System.out.println("Get all trips...");
        return StreamSupport.stream(tripRepository.findAll().spliterator(), false).toArray(Trip[]::new);
    }

    @RequestMapping(value = "/search", method = RequestMethod.GET)
    public Trip[] getTripBetweenHoursHavingLandmark(@RequestParam(value = "landmark") String landmark, @RequestParam(value = "startHour") Integer startHour, @RequestParam(value = "endHour") Integer endHour) {
        System.out.println("Get Trips with landmark: " + landmark + " and startHour: " + startHour + " and endHour: " + endHour);
        return tripRepository.findBetweenHoursHavingLandmark(startHour, endHour, landmark).toArray(Trip[]::new);
    }

    @RequestMapping(method = RequestMethod.POST)
    public Trip create(@RequestBody Trip trip) {
        System.out.println("Saving trip...");
        Optional<Trip> tripOptional = tripRepository.save(trip);
        if(tripOptional.isPresent()) {
            return tripOptional.get();
        }
        return null;
    }

    @RequestMapping(value = "/{id}", method = RequestMethod.PUT)
    public Trip update(@PathVariable Long id, @RequestBody Trip trip) {
        System.out.println("Updating trip...");
        Optional<Trip> tripOptional = tripRepository.update(id, trip);
        if(tripOptional.isEmpty()) {
            return trip;
        }
        return null;
    }

    @RequestMapping(value = "/{id}", method = RequestMethod.DELETE)
    public ResponseEntity<?> delete(@PathVariable Long id) {
        System.out.println("Deleting trip...");
        Optional<Trip> tripOptional = tripRepository.delete(id);
        if(tripOptional.isPresent()) {
            System.out.println("Trip not found");
            return new ResponseEntity<String>(HttpStatus.BAD_REQUEST);
        }

        return new ResponseEntity<Trip>(HttpStatus.OK);
    }
}
