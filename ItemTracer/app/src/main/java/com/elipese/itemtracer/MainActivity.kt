package com.elipese.itemtracer

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.activity.enableEdgeToEdge
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.padding
import androidx.compose.material3.Scaffold
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.setValue
import androidx.compose.ui.Modifier
import androidx.compose.ui.tooling.preview.Preview
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.elipese.itemtracer.ui.theme.ItemTracerTheme
import kotlinx.coroutines.launch
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory
import retrofit2.http.GET

data class TestLogItem(val id: String, val message: String, val timestamp: String)

interface ApiService {
    @GET("api/testlog")
    suspend fun getLog(): List<TestLogItem>

    companion object {
        var apiService: ApiService? = null
        fun getInstance(): ApiService {
            if (apiService == null) {
                apiService = Retrofit.Builder()
                    .baseUrl("http://192.168.31.28:5010/")
                    .addConverterFactory(GsonConverterFactory.create())
                    .build()
                    .create(ApiService::class.java)
            }
            return apiService!!
        }
    }
}

class MainViewModel : ViewModel() {
    var responseText by mutableStateOf("Loading...")
        private set

    init {
        fetchData()
    }

    private fun fetchData() {
        viewModelScope.launch {
            try {
                val api = ApiService.getInstance()
                val result = api.getLog()
                responseText = "Id: ${result.first().id}, Message: ${result.first().message}, Timestamp: ${result.first().timestamp}"
            } catch (e: Exception) {
                responseText = "Error: ${e.message}"
            }
        }
    }
}

class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContent {
            ItemTracerTheme {
                // Initialize the ViewModel
                val viewModel: MainViewModel = androidx.lifecycle.viewmodel.compose.viewModel()

                Scaffold(modifier = Modifier.fillMaxSize()) { innerPadding ->
                    Greeting(
                        name = viewModel.responseText, // Pass the API data here
                        modifier = Modifier.padding(innerPadding)
                    )
                }
            }
        }
    }
}

@Composable
fun Greeting(name: String, modifier: Modifier = Modifier) {
    Text(
        text = "Hello $name!",
        modifier = modifier
    )
}

@Preview(showBackground = true)
@Composable
fun GreetingPreview() {
    ItemTracerTheme {
        Greeting("Android")
    }
}