package rest.client;

import org.springframework.http.HttpRequest;
import org.springframework.http.MediaType;
import org.springframework.http.client.ClientHttpRequestExecution;
import org.springframework.http.client.ClientHttpRequestInterceptor;
import org.springframework.http.client.ClientHttpResponse;
import org.springframework.web.client.RestClient;
import travelAgency.model.Trip;
import travelAgency.clientAMS.ServiceException;

import java.io.IOException;
import java.util.concurrent.Callable;

public class TripsClient {
    RestClient restClient = RestClient.builder().requestInterceptor(new CustomRestClientInterceptor()).build();
    public static final String URL = "http://localhost:8080/travelagency/trips";


    private <T> T execute(Callable<T> callable) {
        try {
            return  callable.call();
        } catch (Exception e) {
            throw new ServiceException(e);
        }
    }

    public Trip[] getAll() {
        return execute(() -> restClient.get().uri(URL).retrieve().body(Trip[].class));
    }

    public Trip[] getTripBetweenHoursHavingLandmark(String landmark, int startHour, int endHour) {
        return execute(() -> restClient.get().uri(String.format("%s?landmark=%s?startHour=%s?endHour=%s", URL, landmark, startHour, endHour)).retrieve().body(Trip[].class));
    }

    public Trip create(Trip trip) {
        return execute(() -> restClient.post().uri(URL).contentType(MediaType.APPLICATION_JSON).body(trip).retrieve().body(Trip.class));
    }

    public Trip update(Long id, Trip trip) {
        return execute(() -> restClient.put().uri(String.format("%s/%s", URL, id)).contentType(MediaType.APPLICATION_JSON).body(trip).retrieve().body(Trip.class));
    }

    public void delete(Long id) {
        execute(() -> restClient.delete().uri(String.format("%s/%s", URL, id)).retrieve().toBodilessEntity());
    }

    public class CustomRestClientInterceptor implements ClientHttpRequestInterceptor {
        @Override
        public ClientHttpResponse intercept(HttpRequest request, byte[] body, ClientHttpRequestExecution execution) throws IOException {
            System.out.println("Sending a " + request.getMethod() + " request to " + request.getURI());
            ClientHttpResponse response = null;

            try {
                response = execution.execute(request, body);
                System.out.println("Got response code: " + response.getStatusCode());
            } catch (IOException e) {
                System.err.println("Execution error " + e);
            }

            return response;
        }
    }
}
