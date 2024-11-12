using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

public class ResearchModel : PageModel
{
    public void OnGet() { }

    public void OnPost()
    {
        // Retrieve form values from Request
        string mainPage = Request.Form["mainPage"];
        string proofForJournal = Request.Form["proofForJournal"];
        string form = Request.Form["form"];
        string researchRank = Request.Form["researchRank"];
        string firstPass = Request.Form["firstPass"];
        string accp = Request.Form["accp"];
        string fee = Request.Form["fee"];
        string optionalLinkMainPage = Request.Form["optionalLinkMainPage"];  // Optional URL for Main Page
        string optionalLinkProof = Request.Form["optionalLinkProof"];        // Optional URL for Proof for Journal
        string optionalLinkForm = Request.Form["optionalLinkForm"];          // Optional URL for Form
        string optionalLinkRank = Request.Form["optionalLinkRank"];          // Optional URL for Research Rank
        string optionalLinkFirstPass = Request.Form["optionalLinkFirstPass"]; // Optional URL for First Pass
        string optionalLinkAcceptance = Request.Form["optionalLinkAcceptance"]; // Optional URL for Acceptance
        string optionalLinkFee = Request.Form["optionalLinkFee"];            // Optional URL for Fee

        string connectionString = "Data Source=XXX;Initial Catalog=RESEARCHDB;Integrated Security=True";

        // SQL query to insert data into ResearchFiles table
        string sqlQuery = @"
            INSERT INTO ResearchFiles (
                MainPage, ProofForJournal, Form, ResearchRank, FirstPass, Accp, Fee,
                OptionalLinkMainPage, OptionalLinkProof, OptionalLinkForm, OptionalLinkRank,
                OptionalLinkFirstPass, OptionalLinkAcceptance, OptionalLinkFee
            )
            VALUES (
                @mainPage, @proofForJournal, @form, @researchRank, @firstPass, @accp, @fee,
                @optionalLinkMainPage, @optionalLinkProof, @optionalLinkForm, @optionalLinkRank,
                @optionalLinkFirstPass, @optionalLinkAcceptance, @optionalLinkFee
            )";

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();

            using (SqlCommand sc = new SqlCommand(sqlQuery, con))
            {
                // Add parameters to prevent SQL injection
                sc.Parameters.AddWithValue("@mainPage", mainPage);
                sc.Parameters.AddWithValue("@proofForJournal", proofForJournal);
                sc.Parameters.AddWithValue("@form", form);
                sc.Parameters.AddWithValue("@researchRank", researchRank);
                sc.Parameters.AddWithValue("@firstPass", firstPass);
                sc.Parameters.AddWithValue("@accp", accp);
                sc.Parameters.AddWithValue("@fee", fee);
                sc.Parameters.AddWithValue("@optionalLinkMainPage", optionalLinkMainPage);
                sc.Parameters.AddWithValue("@optionalLinkProof", optionalLinkProof);
                sc.Parameters.AddWithValue("@optionalLinkForm", optionalLinkForm);
                sc.Parameters.AddWithValue("@optionalLinkRank", optionalLinkRank);
                sc.Parameters.AddWithValue("@optionalLinkFirstPass", optionalLinkFirstPass);
                sc.Parameters.AddWithValue("@optionalLinkAcceptance", optionalLinkAcceptance);
                sc.Parameters.AddWithValue("@optionalLinkFee", optionalLinkFee);

                // Execute the query
                sc.ExecuteNonQuery();
            }
        }
    }
}