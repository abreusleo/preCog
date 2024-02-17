import grpc
from concurrent import futures
import predictor_server_pb2_grpc as pb2_grpc
import predictor_server_pb2 as pb2


class PredictorService(pb2_grpc.PredictorGrpcServicer):

    def __init__(self, *args, **kwargs):
        pass

    def TeamPrediction(self, request, context):
        print("Received a request! Prediction for the following match: " , request.firstTeamId, " VS ", request.secondTeamId)
        #Prediction
        result_prediction = request.firstTeamId
        result = {'id': result_prediction}

        return pb2.PredictionOutput(**result)
    
    def PlayerPrediction(self, request, context):
        print("Received a request! Prediction for the following players: " , request.firstPlayerId, " VS ", request.secondPlayerId)
        #Prediction
        result_prediction = request.firstPlayerId
        result = {'id': result_prediction}

        return pb2.PredictionOutput(**result)
    
    def ChampionshipPrediction(self, request, context):
        print("Received a request! Prediction for the following championship: " , request.id)
        #Prediction
        result_prediction = 1
        result = {'id': result_prediction}

        return pb2.PredictionOutput(**result)


def serve():
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))
    pb2_grpc.add_PredictorGrpcServicer_to_server(PredictorService(), server)
    server.add_insecure_port('[::]:50051')
    server.start()
    print("Server running!")
    server.wait_for_termination()


if __name__ == '__main__':
    serve()