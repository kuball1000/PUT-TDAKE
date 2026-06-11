package lab.app;

import jakarta.ws.rs.client.Client;
import jakarta.ws.rs.client.ClientBuilder;
import jakarta.ws.rs.client.Entity;
import jakarta.ws.rs.core.MediaType;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Client client = ClientBuilder.newClient();
        String baseUrl = "http://localhost:8080/Server-1.0-SNAPSHOT/api/complaints";

        System.out.println("Wszystkie skargi");
        String allComplaints = client.target(baseUrl)
                .request(MediaType.APPLICATION_JSON)
                .get(String.class);
        System.out.println(allComplaints);

        String id = "905";
        System.out.println("\nSkarga o ID " + id);
        String singleComplaint = client.target(baseUrl)
                .path(id)
                .request(MediaType.APPLICATION_JSON)
                .get(String.class);
        System.out.println(singleComplaint);

        System.out.println("\nAktualizacja skargi na 'closed'");
        String updatedComplaintJson = singleComplaint.replace("\"status\":\"open\"", "\"status\":\"closed\"");

        client.target(baseUrl)
                .path(id)
                .request(MediaType.APPLICATION_JSON)
                .put(Entity.json(updatedComplaintJson));
        System.out.println("Zaktualizowano skargę o ID: " + id);

        System.out.println("\nWszystkie otwarte skargi");
        String openComplaints = client.target(baseUrl)
                .queryParam("status", "open")
                .request(MediaType.APPLICATION_JSON)
                .get(String.class);
        System.out.println(openComplaints);

        client.close();
    }
}