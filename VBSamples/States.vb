Imports Hangfire
Imports Hangfire.States

Public Class States
    Sub CreateInEnqueuedState
        #Region "EnqueuedState #1"
        Dim client = new BackgroundJobClient()
        Dim state = new EnqueuedState("critical") ' Use the "critical" queue
             
        client.Create(Sub () Console.WriteLine("Hello"), state)
        #End Region
    End Sub

    Sub ChangeToEnqueuedState
        Dim jobId = "someid"

        #Region "EnqueuedState #2"
        Dim client = new BackgroundJobClient()
        Dim state = new EnqueuedState() ' Use the default queue
            
        client.ChangeState(jobId, state, FailedState.StateName)
        #End Region
    End Sub
End Class
